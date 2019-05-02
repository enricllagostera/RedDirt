using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace RedDirt
{
    public class RedDirtGame : MonoBehaviour
    {
        public UnityEvent whenStartLoadingScene;
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneDelay(sceneName));
        }

        private IEnumerator LoadSceneDelay(string sceneName)
        {
            whenStartLoadingScene?.Invoke();
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        public void BindReaderToRegistry(Magnets.MagneticGestureReader reader)
        {
            if (reader.useTrainingSetFile)
            {
                if (reader.trainingSetFile == null)
                {
                    reader.trainingSetFile = Registry.Instance.trainingSet;
                }
            }
        }
    }
}