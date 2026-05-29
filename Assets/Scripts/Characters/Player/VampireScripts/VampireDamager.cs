using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireDamager : MonoBehaviour
{
    [SerializeField] private float _force;

    public void OnEnemyHitted(IDamageable target)
    {
        target.TakeDamage(_force * Time.deltaTime);
    }
}
