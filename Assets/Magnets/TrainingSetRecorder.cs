using System.Collections;
using System.Collections.Generic;
using PDollarGestureRecognizer;
using RedDirt;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Magnets
{
    public class TrainingSetRecorder : MonoBehaviour
    {
        public KeyCode recordKey;

        public TrainingSet trainingSetAsset;
        public UnityEvent onStartedRecording, onFinishedRecording;

        private List<Point> points;
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
                var repeated = trainingSetAsset.allGestures.Find(g => g.Name == targetGestureName);
                if (repeated != null)
                {
                    trainingSetAsset.allGestures.Remove(repeated);
                }
                trainingSetAsset.allGestures.Add(new Gesture(points.ToArray(), targetGestureName));
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
            points = new List<Point>();
            isRecording = false;
            trainingSetAsset = Registry.Instance.trainingSet;
        }
        void Update()
        {
            if (isRecording)
            {
                points.Add(new Point(inputValue.y, inputValue.z, strokeId));
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