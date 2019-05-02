using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedDirt
{
    public class EyeController : MonoBehaviour
    {
        public Animator animator, signAnimator;
        public GameObject msgPanel;
        public GameObject forwardSign, rememberSign, downSign, staySign;

        public Vector3 withoutTextPosition, withTextPosition;
        private bool eyeOpen;
        private float smoothFactor = 7f;
        private Color targetSignColor;
        private SpriteRenderer signSprite;

        #region [PublicAPI]

        public void ShowSign(string sign)
        {
            CloseEye();
            StartCoroutine(FadeSign(sign));
        }

        public void OpenEye()
        {
            StopAllCoroutines();
            eyeOpen = true;
            StartCoroutine(OpenAnimation());
        }

        public void CloseEye()
        {
            StopAllCoroutines();
            eyeOpen = false;
            animator.SetTrigger("ClosedEye");
        }

        public void Blink()
        {
            StartCoroutine(BlinkAnimation());
        }
        #endregion

        private void Awake()
        {
            signSprite = signAnimator.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Vector3 targetPosition = (msgPanel.activeInHierarchy) ? withTextPosition : withoutTextPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
            if (signAnimator.gameObject.activeInHierarchy)
            {
                signSprite.color = Color.Lerp(signSprite.color, targetSignColor, Time.deltaTime * smoothFactor);
            }
        }

        #region [PrivateMethods]

        private IEnumerator FadeSign(string sign)
        {
            if (sign.ToLower() == "no match")
            {
                sign = "default";
            }
            signSprite.color = Color.clear;
            signAnimator.gameObject.SetActive(true);
            signAnimator.Play(sign);
            targetSignColor = Color.white;
            yield return new WaitForSeconds(2f);
            targetSignColor = Color.clear;
            yield return new WaitForSeconds(1f);
            signAnimator.gameObject.SetActive(false);
        }
        private IEnumerator OpenAnimation()
        {
            animator.SetTrigger("OpenedEye");
            while (eyeOpen)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(1.5f, 2.5f));
                StartCoroutine(BlinkAnimation());
            }
        }

        private IEnumerator BlinkAnimation()
        {
            animator.SetTrigger("ClosedEye");
            yield return new WaitForSeconds(0.1f);
            animator.SetTrigger("OpenedEye");
        }
        #endregion
    }
}