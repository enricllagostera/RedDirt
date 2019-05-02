using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DollarOne;
using System;
using TMPro;
using UnityEngine.Events;
using RedDirt;

namespace Magnets
{
    public class MagneticOneDollar : MonoBehaviour
    {
        public bool useTrainingSetFile = false;
        public OneDollarTrainingSet trainingSetFile;
        public List<Unistroke> trainingSet = new List<Unistroke>();
        public MagneticOneDollarEvent onInit;
        public OneDollarPatternResultEvent onRecognizedGesture;
        public StringEvent onRecognizedName;
        public StringEvent onDebugValueProcessed;
        private List<Vector2> points;
        private Vector3 inputValue;
        private int strokeId;
        private bool isRecordingForTrainingSet;
        private bool isRecordingForRecognizing;
        public GameObject oscSensor, nativeSensor;
        public DollarOne.DollarRecognizer recognizer;


        #region [Public API]

        public void UpdateInputValue(Vector3 value)
        {
            inputValue = value;
            onDebugValueProcessed?.Invoke(value.ToString());
        }

        public void SetRecordingMode(bool recordMode)
        {
            // just started recording
            if (recordMode)
            {
                strokeId = 0;
                points.Clear();
            }
            // just stopped recording
            else
            {
                // has a recorded training set
                if (points.Count > 0)
                {
                    var temp = recognizer.SavePattern("gesture_" + (trainingSetFile.allPatterns.Count + 1), points);
                    trainingSetFile.allPatterns.Add(temp);
                }
            }
            isRecordingForTrainingSet = recordMode;
        }

        public void SetRecognizingMode(bool recognizingMode)
        {
            if (recognizingMode)
            {
                strokeId = 0;
                points.Clear();
            }
            else
            {
                // runs the classification algorithm
                if (points.Count > 0)
                {
                    if (useTrainingSetFile)
                    {
                        trainingSet = trainingSetFile.allPatterns;
                    }
                    var result = recognizer.Recognize(points, trainingSet);
                    onRecognizedGesture?.Invoke(result);
                    if (result.Match != null)
                    {
                        onRecognizedName?.Invoke(result.Match.name);
                    }
                    else
                    {
                        onRecognizedName?.Invoke("No match for gesture.");
                    }
                }
            }
            isRecordingForRecognizing = recognizingMode;
        }

        #endregion

        #region [Messages]

        private void Awake()
        {
            trainingSetFile = Registry.Instance.oneDollarTrainingSet;
            recognizer = new DollarOne.DollarRecognizer();
#if UNITY_EDITOR
            oscSensor.SetActive(true);
            nativeSensor.SetActive(false);
#else
            oscSensor.SetActive(false);
            nativeSensor.SetActive(true);
#endif
        }

        void Start()
        {
            points = new List<Vector2>();
            if (useTrainingSetFile)
            {
                trainingSet = trainingSetFile.allPatterns;
            }
            isRecordingForRecognizing = false;
            isRecordingForTrainingSet = false;
        }

        void Update()
        {
            if (isRecordingForTrainingSet || isRecordingForRecognizing)
            {
                points.Add(new Vector2(inputValue.y, inputValue.z));
            }
        }

        #endregion
    }

}