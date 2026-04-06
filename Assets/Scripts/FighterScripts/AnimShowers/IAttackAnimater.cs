using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackAnimater
{
    event Action<bool> StartedAttack;
    bool IsAnimateAttack();
    void PlayAttack();
}
