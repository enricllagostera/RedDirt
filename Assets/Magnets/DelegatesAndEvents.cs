using System;
using PDollarGestureRecognizer;
using DollarOne;
using UnityEngine;
using UnityEngine.Events;

namespace Magnets
{
    [Serializable]
    public class StringEvent : UnityEvent<string> { }

    [Serializable]
    public class Vector3Event : UnityEvent<Vector3> { }

    [Serializable]
    public class GestureResultEvent : UnityEvent<PDollarGestureRecognizer.Result> { }
    [Serializable]
    public class OneDollarPatternResultEvent : UnityEvent<DollarOne.Result> { }

    [Serializable]
    public class MagneticReaderEvent : UnityEvent<MagneticGestureReader> { }

    [Serializable]
    public class MagneticOneDollarEvent : UnityEvent<MagneticOneDollar> { }
}