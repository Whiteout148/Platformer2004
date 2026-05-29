using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public abstract class UIValueShower : UIBase
{
    protected const float MaxPercent = 100f;

    public abstract void OnValueChanged(float maxValue, float currentValue);
    public override void Hide()
    {
        base.Hide();
    }
}
