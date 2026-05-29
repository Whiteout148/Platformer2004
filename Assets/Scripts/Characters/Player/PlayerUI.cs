using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : UIActionSubscriber
{
    [SerializeField] private Vampire _vampire;
    [SerializeField] private VampireUI _uiVampire;

    protected override void OnEnable()
    {
        base.OnEnable();

        _vampire.AbsorbingStart += _uiVampire.OnAbsorbStart;
        _vampire.ReloadingStart += _uiVampire.OnAbsorbEnd;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _vampire.AbsorbingStart -= _uiVampire.OnAbsorbStart;
        _vampire.ReloadingStart -= _uiVampire.OnAbsorbEnd;
    }
}
