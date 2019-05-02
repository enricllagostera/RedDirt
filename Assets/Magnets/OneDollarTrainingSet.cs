using UnityEngine;
using System.Collections.Generic;
using DollarOne;

namespace Magnets
{

    [CreateAssetMenu(fileName = "OneDollarTrainingSet", menuName = "magnets/OneDollarTrainingSet", order = 1)]
    public class OneDollarTrainingSet : ScriptableObject
    {
        public List<Unistroke> allPatterns;
    }
}