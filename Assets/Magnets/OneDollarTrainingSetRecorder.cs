using System.Collections;
using System.Collections.Generic;
using DollarOne;
using PDollarGestureRecognizer;
using RedDirt;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Magnets
{
    public class OneDollarTrainingSetRecorder : MonoBehaviour
    {
        public KeyCode recordKey;

        public OneDollarTrainingSet trainingSetAsset;

        public UnityEvent onStartedRecording, onFinishedRecording;

        private List<Vector2> points;
        private bool isRecording;
        private string targetGestureName;
        private int strokeId;
        private Vector3 inputValue;



        public void StartRecording(BaseEventData eventData)
        {
            targetGestureName = eventData.selectedObject.name;
            print(targetGestureName);
            strokeId = 0;
            points.Clear();
            onStartedRecording?.Invoke();
            isRecording = true;
        }

        public void StopRecording()
        {
            // has a recorded training set
            if (points.Count > 0)
            {
                var repeated = trainingSetAsset.allPatterns.Find(g => g.name == targetGestureName);
                if (repeated != null)
                {
                    trainingSetAsset.allPatterns.Remove(repeated);
                }
                var temp = new Unistroke(targetGestureName, points);
                trainingSetAsset.allPatterns.Add(temp);
            }
            onFinishedRecording?.Invoke();
            isRecording = false;
        }

        public void UpdateInputValue(Vector3 value)
        {
            inputValue = value;
        }

        private void Awake()
        {
            points = new List<Vector2>();
            isRecording = false;
            trainingSetAsset = Registry.Instance.oneDollarTrainingSet;
        }
        void Update()
        {
            if (isRecording)
            {
                points.Add(new Vector2(inputValue.y, inputValue.z));
            }
            if (Input.GetKeyDown(recordKey))
            {
                if (onStartedRecording != null) onStartedRecording.Invoke();
            }

            if (Input.GetKeyUp(recordKey))
            {
                if (onFinishedRecording != null) onFinishedRecording.Invoke();
            }
        }
    }

}