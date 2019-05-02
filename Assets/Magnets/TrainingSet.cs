using UnityEngine;
using System.Collections.Generic;
using PDollarGestureRecognizer;

namespace Magnets
{

    [CreateAssetMenu(fileName = "TrainingSet", menuName = "magnets/TrainingSet", order = 0)]
    public class TrainingSet : ScriptableObject
    {
        public List<Gesture> allGestures;
    }
}