using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Spooky.Utilities.Effects
{
    public class ParticleSystemFizzle : MonoBehaviour
    {
        public bool ScaleDown = true;
        public bool LowerEmission = false;
        public float DelayBeforeStart;
        public float Duration;
        public bool DetachFromParent = true;
        private Tweener _ScalingTweener;
        private Coroutine _FizzleCoroutine;

        public void StartFizzle(bool destroyAtEnd = true)
        {
            if (isActiveAndEnabled)
            {
                _FizzleCoroutine = StartCoroutine(Fizzle(destroyAtEnd));
            }
        }

        public IEnumerator Fizzle(bool destroyAtEnd = true)
        {

            if (DetachFromParent)
            {
                transform.SetParent(null);
            }

            if (destroyAtEnd)
            {
                Destroy(gameObject, DelayBeforeStart + Duration);
            }

            if (!gameObject.activeSelf || !gameObject.activeInHierarchy)
            {
                yield break;
            }

            yield return new WaitForSeconds(DelayBeforeStart);

            if (LowerEmission)
            {
                gameObject.StopEmission();
            }

            if (ScaleDown)
            {
                _ScalingTweener = gameObject.transform.DOScale(0, Duration);
            }

            foreach (var particleSystem in GetComponentsInChildren<ParticleSystem>())
            {
                var module = particleSystem.main;
                module.loop = false;
            }
        }


        private void OnDestroy()
        {
            if (_FizzleCoroutine != null)
            {
                StopCoroutine(_FizzleCoroutine);
            }

            if (_ScalingTweener != null)
            {
                _ScalingTweener.Kill();
            }
        }
    }

    public static class FizzleExtenstions
    {
        public static void Fizzle(this GameObject go, float delayBeforeStart, float fizzleDuration = 0, bool destroyAtEnd = true)
        {
            if (go == null) return;
            go.transform.SetParent(null);
            var fizzleEffect = go.GetComponent<ParticleSystemFizzle>();
            if (fizzleEffect == null)
            {
                fizzleEffect = go.AddComponent<ParticleSystemFizzle>();
                fizzleEffect.DelayBeforeStart = delayBeforeStart;
                fizzleEffect.Duration = fizzleDuration;
            }

            fizzleEffect.StartFizzle(destroyAtEnd);
        }
    }

}