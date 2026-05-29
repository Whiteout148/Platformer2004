using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionSubscriber : MonoBehaviour
{
    [SerializeField] protected SmoothlyBarShower HealthBarShower;
    [SerializeField] protected TextShower TextHealthShower;
    [SerializeField] protected Health Health;

    protected virtual void OnEnable()
    {
        Health.Dead += OnDie;
        Health.ValueChanged += HealthBarShower.OnValueChanged;
        Health.ValueChanged += TextHealthShower.OnValueChanged;
        Health.Dead += HealthBarShower.Hide;
        Health.Dead += TextHealthShower.Hide;
    }

    protected virtual void OnDisable()
    {
        Health.Dead -= OnDie;
    }

    protected void OnDie()
    {
        Health.ValueChanged -= HealthBarShower.OnValueChanged;
        Health.ValueChanged -= TextHealthShower.OnValueChanged;
        Health.Dead -= HealthBarShower.Hide;
        Health.Dead -= TextHealthShower.Hide;
    }
}
