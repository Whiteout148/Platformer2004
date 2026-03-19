using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour, IDamageable
{
    [SerializeField] protected float Force;
    [SerializeField] protected Health Health;
    [SerializeField] protected Mover CharacterMover;
    [SerializeField] protected Weapon CharacterWeapon;
    [SerializeField] protected AnimationShower Shower;

    private void OnEnable()
    {
        CharacterMover.StartMoved += Shower.PlayMove;
        CharacterMover.EndMoved += Shower.StopPlayMove;
        CharacterWeapon.HittedOther += OnHitOther;
    }

    private void OnDisable()
    {
        CharacterMover.StartMoved -= Shower.PlayMove;
        CharacterMover.EndMoved -= Shower.StopPlayMove;
        CharacterWeapon.HittedOther -= OnHitOther;
    }

    public virtual void TakeDamage(float damage)
    {
        Health.Reduce(damage);
    }

    public virtual void OnHitOther(IDamageable target)
    {
        if (Shower.IsAnimateAttack())
        {
            target.TakeDamage(Force);
        }
    }

    public void Attack()
    {
        if (!Shower.IsAnimateAttack())
        {
            Shower.PlayAttack();
        }
    }

    public abstract void ShowAbility();
}
