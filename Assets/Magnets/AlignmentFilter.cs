using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magnets
{
    public class AlignmentFilter : MonoBehaviour
    {
        public Vector3 baseOffset = Vector3.zero;
        public Vector3 currentValue;
        public bool hasOffset;
        public Vector3Event onFilteredValue;

        #region [Public API]
        public void UpdateSourceValue(Vector3 source)
        {
            if (!hasOffset)
            {
                baseOffset = source;
                hasOffset = true;
            }
            currentValue = source - baseOffset;
            if (onFilteredValue != null) onFilteredValue.Invoke(currentValue);
        }

        public void ResetOffsetOnNextUpdate()
        {
            hasOffset = false;
        }
        #endregion

        #region [Messages]
        private void OnEnable()
        {
            ResetOffsetOnNextUpdate();
        }

        #endregion
    }

}