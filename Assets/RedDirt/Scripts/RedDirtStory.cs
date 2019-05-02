using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.Events;
using PDollarGestureRecognizer;
using System;
using UnityEngine.UI;

namespace RedDirt
{
    public class RedDirtStory : MonoBehaviour
    {
        [Header("Story & Logic")]
        public TextAsset inkAsset;
        public bool playOnStart;
        [Range(0.2f, 0.99f)] public float gestureScoreThreshold;
        private bool isPlaying;
        bool waitingForChoice = false;
        Story inkStory;

        [Header("Story UI")]
        public Text msgLbl;
        public GameObject msgPanel;

        [Header("Events")]
        public UnityEvent onStartDecision;
        public UnityEvent onEndDecision;
        public VoiceOverEvent onShowNewLine;
        private bool justFinishedShowingLine;
        public Magnets.MagneticGestureReader reader;

        public Magnets.MagneticOneDollar readerOneDollar;

        #region [PublicAPI]
        public void ParseGestureChoice(DollarOne.Result gestureResult)
        {
            if (waitingForChoice)
            {
                for (int i = 0; i < inkStory.currentChoices.Count; i++)
                {
                    if (gestureResult.Match != null)
                    {
                        if (gestureResult.Match.name == inkStory.currentChoices[i].text.ToLower() && gestureResult.Score > gestureScoreThreshold)
                        {
                            ChooseChoice(i);
                            return;
                        }
                    }

                }
                // did not find any choice, picks last as default
                ChooseChoice(inkStory.currentChoices.Count - 1);
            }
        }
        public void ParseGestureChoice(PDollarGestureRecognizer.Result gestureResult)
        {
            if (waitingForChoice)
            {
                for (int i = 0; i < inkStory.currentChoices.Count; i++)
                {
                    if (gestureResult.GestureClass.ToLower() == inkStory.currentChoices[i].text.ToLower() && gestureResult.Score > gestureScoreThreshold)
                    {
                        ChooseChoice(i);
                        return;
                    }
                }
                // did not find any choice, picks last as default
                ChooseChoice(inkStory.currentChoices.Count - 1);
            }
        }

        public void OnFinishedShowingLine()
        {
            justFinishedShowingLine = true;
        }

        public void SetTextUI(bool active)
        {
            if (Registry.Instance.showTextSetting)
            {
                msgPanel.SetActive(active);
            }
            else
            {
                msgPanel.SetActive(false);
            }
        }

        #endregion

        #region [Messages]

        private void Awake()
        {
            inkStory = new Story(inkAsset.text);
            waitingForChoice = false;
            isPlaying = false;
            justFinishedShowingLine = true;
            //reader.trainingSetFile = GameObject.FindObjectOfType<Registry>().trainingSet;
        }

        private IEnumerator Start()
        {
            if (playOnStart)
            {
                yield return new WaitForSeconds(3f);
                PlayStory();
            }
        }

        #endregion

        #region [Private Methods]

        private void PlayStory()
        {
            isPlaying = true;
            StartCoroutine(ShowKnot());
        }


        private void ChooseChoice(int choice)
        {
            inkStory.ChooseChoiceIndex(choice);
            StartCoroutine(ShowKnot());
        }

        private IEnumerator ShowKnot()
        {
            yield return new WaitForSeconds(3f);
            while (inkStory.canContinue)
            {

                waitingForChoice = false;
                if (justFinishedShowingLine)
                {
                    justFinishedShowingLine = false;
                    msgLbl.text = inkStory.Continue();
                    var tags = inkStory.currentTags;
                    onShowNewLine?.Invoke(tags);
                }
                yield return new WaitForEndOfFrame();
            }
            while (!justFinishedShowingLine)
            {
                yield return new WaitForEndOfFrame();
            }
            if (!Registry.Instance.showTextSetting)
            {
                yield return new WaitForSeconds(1f);
            }
            if (inkStory.currentChoices.Count > 0)
            {
                msgLbl.text = "";
                for (int i = 0; i < inkStory.currentChoices.Count; ++i)
                {
                    Choice choice = inkStory.currentChoices[i];
                    msgLbl.text += "\nChoice " + (i + 1) + ". " + choice.text;
                }
                msgLbl.text += "\n\n";
                waitingForChoice = true;
                if (onStartDecision != null)
                {
                    onStartDecision.Invoke();
                }
                StartCoroutine(EndChoicePeriod());
            }
        }

        private IEnumerator EndChoicePeriod()
        {
            yield return new WaitForSeconds(5f);
            onEndDecision?.Invoke();
        }

        #endregion
    }
}
