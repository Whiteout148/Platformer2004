using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class TextShower : UIValueShower
{
    [SerializeField] private TextMeshProUGUI _text;

    public override void OnValueChanged(float maxValue, float currentValue)
    {
        float percentValue = (currentValue / maxValue) * MaxPercent;

        int resultValue = Convert.ToInt32(currentValue);

        _text.text = resultValue.ToString();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
