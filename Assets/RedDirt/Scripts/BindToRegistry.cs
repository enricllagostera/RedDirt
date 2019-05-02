using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedDirt
{

    public class BindToRegistry : MonoBehaviour
    {
        public void SetTextMode(bool value)
        {
            Registry.Instance.showTextSetting = value;
        }
    }

}