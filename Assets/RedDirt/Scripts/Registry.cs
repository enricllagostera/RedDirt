using System.Collections;
using System.Collections.Generic;
using Magnets;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedDirt
{
    public class Registry : Singleton<Registry>
    {
        public TrainingSet trainingSet;
        public OneDollarTrainingSet oneDollarTrainingSet;

        [Header("Clean-up objects")]
        public List<GameObject> discard;
        public bool loadStartScene = false;
        public bool showTextSetting;

        private void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            DontDestroyOnLoad(this.gameObject);
        }

        IEnumerator Start()
        {
            if (loadStartScene)
            {
                yield return new WaitForSeconds(3f);
                foreach (var go in discard)
                {
                    Destroy(go, 0.1f);
                }
                SceneManager.LoadScene("StartMenu", LoadSceneMode.Additive);
            }
        }
    }

}