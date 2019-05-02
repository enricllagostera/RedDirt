using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RedDirt
{
    public class VoiceOver : MonoBehaviour
    {
        public AudioSource audioPlayer;
        public AudioClip defaultClip;
        public UnityEvent onFinishPlayingLine;
        public VoiceOverDictionary voiceOverLines;
        private bool wasPlaying;

        #region [PublicAPI]
        public void PlayNextLine(List<string> lineTags)
        {
            AudioClip clip = null;
            foreach (var tag in lineTags)
            {
                clip = FindAudioForLine(tag);
                if (clip != null)
                {
                    break;
                }
            }
            audioPlayer.Stop();
            if (clip == null)
            {
                clip = defaultClip;
            }
            audioPlayer.PlayOneShot(clip, 1f);
        }

        public void StopPlayingLine()
        {
            audioPlayer.Stop();
            wasPlaying = false;
        }
        #endregion

        #region [Messages]
        private void Awake()
        {
            wasPlaying = false;
            var allLineFiles = Resources.LoadAll<AudioClip>("VoiceOver");
            foreach (var line in allLineFiles)
            {
                VOLines.Add(line.name, line);
            }
        }

        private void Update()
        {
            if (Registry.Instance.showTextSetting)
            {
                return;
            }
            if (wasPlaying && !audioPlayer.isPlaying)
            {
                onFinishPlayingLine?.Invoke();
            }
            wasPlaying = audioPlayer.isPlaying;
        }
        #endregion

        #region [PrivateMethods]
        private IDictionary<string, AudioClip> VOLines
        {
            get { return voiceOverLines as IDictionary<string, AudioClip>; }
            set { voiceOverLines.CopyFrom(value); }
        }

        private AudioClip FindAudioForLine(string tag)
        {
            AudioClip result = null;
            if (VOLines.TryGetValue(tag, out result))
            {
                return result;
            }
            return result;
        }
        #endregion
    }
}