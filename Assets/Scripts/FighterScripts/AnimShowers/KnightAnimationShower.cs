using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class KnightAnimationShower : AnimationShower
{
    private const string CastingBoolName = "IsCasting";

    private int IsCasting = Animator.StringToHash(CastingBoolName);

    public void PlayCasting()
    {
        Animator.SetBool(IsCasting, true);
    }

    public void StopPlayCasting()
    {
        Animator.SetBool(IsCasting, false);
    }
}
