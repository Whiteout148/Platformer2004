using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbCircleShower : MonoBehaviour
{
    [SerializeField] private float _changeingTime = 1f;
    [SerializeField] private float _normalVisibility;
    [SerializeField] private SpriteRenderer _sprite;

    private Coroutine _changeingCoroutine;
    private Color _standartColor;

    private void Awake()
    {
        Color standartColor = _sprite.color;
        standartColor.a = _normalVisibility;
        _standartColor = standartColor;
    }

    public void FadeIn()
    {
        _changeingCoroutine = StartCoroutine(ChangeValue(0f, _normalVisibility));
    }

    public void FadeOut()
    {
        _changeingCoroutine = StartCoroutine(ChangeValue(_normalVisibility, 0f));
    }

    private IEnumerator ChangeValue(float startVisibility, float endVisibility)
    {
        Color currentColor = _standartColor;
        currentColor.a = startVisibility;

        while (!Mathf.Approximately(_sprite.color.a, endVisibility))
        {
            currentColor.a = Mathf.MoveTowards(currentColor.a, endVisibility, Time.deltaTime / _changeingTime);
            _sprite.color = currentColor;

            yield return null;
        }

        currentColor.a = endVisibility;
        _sprite.color = currentColor;

        _changeingCoroutine = null;
    }
}
