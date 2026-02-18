using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Fighter
{
    [SerializeField] private float _armor;

    public override void TakeDamage(float damage)
    {
        Health -= damage - _armor;

        if (damage - _armor < 0)
        {
            damage = 0;
        }
    }
}
