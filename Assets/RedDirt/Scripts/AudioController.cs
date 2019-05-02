using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RedDirt
{

    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        public float baseVolume;
        public float targetVolume;
        public float transitionFactor;
        private AudioSource audioPlayer;

        public void FadeIn()
        {
            //audioPlayer.volume = 0f;
            targetVolume = baseVolume;
        }

        public void FadeOut()
        {
            //audioPlayer.volume = baseVolume;
            targetVolume = 0f;
        }


        private void Awake()
        {
            audioPlayer = GetComponent<AudioSource>();
        }

        private void Update()
        {
            audioPlayer.volume = Mathf.Lerp(audioPlayer.volume, targetVolume, Time.deltaTime * transitionFactor);
        }
    }

}