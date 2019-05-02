using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedDirt
{
    public class IntroCompass : MonoBehaviour
    {
        public Vector3 magnetValues;
        private bool hasSouthDirection;
        private Vector3 southDirection;

        private void Start()
        {
            hasSouthDirection = false;
            southDirection = Vector3.zero;
        }

        private void Update()
        {
            if (hasSouthDirection)
            {
                var result = Vector3.Dot(magnetValues.normalized, southDirection);
                print(result);
            }
        }

        #region Events

        public void UpdateMagnetValues(Vector3 newValues)
        {
            magnetValues = newValues;
        }

        public void DefineSouthDirection()
        {
            southDirection = magnetValues.normalized;
            hasSouthDirection = true;
        }

        #endregion
    }
}