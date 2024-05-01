using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ScreenShake : MonoBehaviour
{
  
        public bool start = false;
        public AnimationCurve curve;
        public float duration = 1f;

    public GameObject Player;

        void Update()
        {
            if (start)
            {
                start = false;
                StartCoroutine(Shaking());
            }
        }
        IEnumerator Shaking()
        {
            Vector3 startPosition = transform.position;
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float strength = curve.Evaluate(elapsedTime / duration);
                transform.position = startPosition + Random.insideUnitSphere;
                yield return null;
            }
            transform.position = startPosition;
        }
    }


