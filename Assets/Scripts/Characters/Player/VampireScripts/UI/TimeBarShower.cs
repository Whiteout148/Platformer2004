using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarShower : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Coroutine _timerCoroutine;

    public void FadeIn(float time)
    {
        _timerCoroutine = StartCoroutine(ChangeValue(time ,0f, _slider.maxValue));
    }

    public void FadeOut(float time)
    {
        _timerCoroutine = StartCoroutine(ChangeValue(time, _slider.maxValue, 0f));
    }

    public void OnDie()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator ChangeValue(float targetTime, float startValue, float endValue)
    {
        float time = 0f;

        while (time < targetTime)
        {
            float dividedTime = time / targetTime;

            _slider.value = Mathf.Lerp(startValue, endValue, dividedTime);

            time += Time.deltaTime;

            yield return null;
        }

        _slider.value = endValue;

        _timerCoroutine = null;
    }
}
