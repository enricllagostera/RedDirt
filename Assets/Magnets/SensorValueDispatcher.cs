using System.Collections;
using System.Collections.Generic;
using UnityAndroidSensors.Scripts.Utils.SmartVars;
using UnityEngine;

namespace Magnets
{
    public class SensorValueDispatcher : MonoBehaviour
    {
        public Vector3Var v3Value;
        public Vector3Event onNewValue;
        public StringEvent onNewValueDebug;

        void Update()
        {
            onNewValue?.Invoke(v3Value.value);
            onNewValueDebug?.Invoke(v3Value.value.ToString());
        }
    }

}