using System.Collections;
using System.Collections.Generic;
using DollarOne;
using UnityEngine;

public class DollarOneTest : MonoBehaviour
{
    DollarRecognizer recognizer;
    public bool recordingMode;
    public List<Vector2> points;

    public List<Unistroke> patterns;
    private bool recognizingMode;

    private void Awake()
    {
        recognizer = new DollarRecognizer();
        patterns = new List<Unistroke>();
    }

    // Update is called once per frame
    void Update()
    {

        if (recordingMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                points = new List<Vector2>();
            }
            if (Input.GetMouseButton(0))
            {
                var screenPoint = Input.mousePosition;
                points.Add(screenPoint);
            }
            if (Input.GetMouseButtonUp(0))
            {
                var saved = recognizer.SavePattern("pattern_" + Time.realtimeSinceStartup, points);
                patterns.Add(saved);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                points = new List<Vector2>();
            }
            if (Input.GetMouseButton(0))
            {
                var screenPoint = Input.mousePosition;
                points.Add(screenPoint);
            }
            if (Input.GetMouseButtonUp(0))
            {
                //var result = recognizer.Recognize(points, trai);
                //Debug.Log(result.Match + " : " + result.Score + " : " + result.Angle);
            }
        }

    }
}
