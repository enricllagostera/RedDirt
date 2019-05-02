using System.Collections;
using System.Collections.Generic;
using PDollarGestureRecognizer;
using UnityEngine;
using UnityEngine.Events;

namespace Magnets
{
    public class DebugGestureParser : MonoBehaviour
    {
        public UnityEvent onStartRecognizing, onEndRecognizing;
        public StringEvent onParsedGesture;
        public KeyCode reconModeKey;
        private int previousTouchCount;

        public void ParseGestureChoice(Result gestureResult)
        {
            Debug.Log(string.Format("Gesture [{0}] {1}", gestureResult.GestureClass, gestureResult.Score));
            onParsedGesture?.Invoke(string.Format("Gesture [{0}] {1}", gestureResult.GestureClass, gestureResult.Score));
        }

        private void Update()
        {
            int currentTouchCount = Input.touchCount;
            bool justTouched = (currentTouchCount > 0 && previousTouchCount == 0);
            if (Input.GetKeyDown(reconModeKey) || justTouched)
            {
                if (onStartRecognizing != null) onStartRecognizing.Invoke();
            }
            bool justReleased = (currentTouchCount == 0 && previousTouchCount > 0);
            if (Input.GetKeyUp(reconModeKey) || justReleased)
            {
                if (onEndRecognizing != null) onEndRecognizing.Invoke();
            }
            previousTouchCount = currentTouchCount;
        }
    }

}