using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magnets
{

    public class InterpolatorFilter : MonoBehaviour
    {
        Vector3 inputValue;
        public Vector3 topLeft, topRight, bottomRight, bottomLeft;
        public RectTransform cursorGO;

        public void SetCorner(string id)
        {
            switch (id.ToLower())
            {
                case "tl": topLeft = inputValue; break;
                case "tr": topRight = inputValue; break;
                case "br": bottomRight = inputValue; break;
                case "bl": bottomLeft = inputValue; break;
                default:
                    throw new UnityException("Invalid corner for calibration: " + id);
            }
        }

        public void UpdateInputValue(Vector3 value)
        {
            inputValue = value;
        }

        public void Update()
        {
            var diffX = topLeft - topRight;
            var diffY = topLeft - bottomLeft;
            var cursor = new Vector3();
            cursor.x = inputValue.x.Remap(topLeft.x, topRight.x, -5f, 5f);
            cursor.y = inputValue.y.Remap(topLeft.y, bottomLeft.y, -5f, 5f);
            cursorGO.localPosition = cursor;
        }
    }

}