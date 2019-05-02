using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Magnets
{
    public class WeightedV3Filter : MonoBehaviour
    {
        public Vector3 weights;
        public Vector3 weightedV3;
        public Vector3Event OnNewValue;

        #region [Public API]

        public void UpdateInputValue(Vector3 value)
        {
            weightedV3 = value;
            weightedV3.x *= weights.x;
            weightedV3.y *= weights.y;
            weightedV3.z *= weights.z;
            if (OnNewValue != null) OnNewValue.Invoke(weightedV3);
        }
        #endregion

        #region [Messages]
        private void OnEnable()
        {
            weightedV3 = new Vector3();
        }
        #endregion
    }

}