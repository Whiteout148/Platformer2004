using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Fighter
{
    [SerializeField] private float _defendingTime = 2f;
    [SerializeField] private float _armor;
    [SerializeField] private KnightAnimationShower _shower;

    private WaitForSeconds _sleep;
    private Coroutine _defendingCoroutine;

    private bool _isCasting = false;

    private void Awake()
    {
        _sleep = new WaitForSeconds(_defendingTime);
    }

    public override void TakeDamage(float damage)
    {
        if (damage - _armor < 0f || _isCasting)
        {
            damage = 0f;
        }
        else
        {
            damage -= _armor;
        }

        base.TakeDamage(damage);
    }

    public override void ShowAbility()
    {
        if (!_isCasting)
        {
            _defendingCoroutine = StartCoroutine(Defend());
        }
    }

    private IEnumerator Defend()
    {
        _isCasting = true;
        _shower.PlayCasting();

        if (TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        yield return _sleep;

        _shower.StopPlayCasting();

        rigidbody.constraints = RigidbodyConstraints2D.None;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        _isCasting = false;
        _defendingCoroutine = null;
    }
}
