using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireUI : MonoBehaviour
{
    [SerializeField] private TimeBarShower _reloadStateShower;
    [SerializeField] private AbsorbCircleShower _circleShower;

    public void OnAbsorbStart(float time)
    {
        _reloadStateShower.FadeOut(time);
        _circleShower.FadeIn();
    }

    public void OnAbsorbEnd(float time)
    {
        _reloadStateShower.FadeIn(time);
        _circleShower.FadeOut();
    }
}
