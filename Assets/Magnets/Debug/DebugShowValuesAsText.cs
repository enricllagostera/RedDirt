using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Magnets
{
    public class DebugShowValuesAsText : MonoBehaviour
    {
        public TextMeshProUGUI label;
        public float limit;
        public string msg;
        public void ShowFloat(float value)
        {
            label.text = value.ToString();
        }

        public void ShowString(string value)
        {
            label.text = value;
        }

        public void ShowMessageOnGreaterThanFloat(float value)
        {
            if (value >= limit)
                label.text = msg;
        }

        public void ShowMessageOnGreaterThanMagnitude(Vector3 value)
        {
            if (value.magnitude >= limit)
                label.text = msg;
            else
            {
                label.text = "";
            }
        }
    }
}