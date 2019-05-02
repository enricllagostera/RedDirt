using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTouchCount : MonoBehaviour
{
    public Text lbl;
    void Update()
    {
        lbl.text = Input.touchCount.ToString();
    }
}
