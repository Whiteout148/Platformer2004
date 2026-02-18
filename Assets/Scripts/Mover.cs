using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering;

public class Mover : MonoBehaviour
{
    protected const float LeftScaleX = -1f;
    protected const float RightScaleX = 1f;

    [SerializeField] protected float Step = 1f;
    [SerializeField] protected float Speed = 1f;
    [SerializeField] protected Jumper Jumper;

    protected bool IsMove = false;
    protected Coroutine MoveCoroutine;
    protected Vector3 ScaleOnGoRight;
    protected Vector3 ScaleOnGoLeft;

    public event Action StartMoved;
    public event Action EndMoved;

    private void Awake()
    {
        ScaleOnGoLeft = new Vector3(LeftScaleX, transform.localScale.y, transform.localScale.z);
        ScaleOnGoRight = new Vector3(RightScaleX, transform.localScale.y, transform.localScale.z);
    }

    public virtual void Move(float step)
    {
        StartMoved?.Invoke();
        IsMove = true;
    }

    public virtual void StopMove()
    {
        EndMoved?.Invoke();
        IsMove = false;
    }

    public virtual Vector3 GetScale(float step)
    {
        return new Vector3(step, transform.localScale.y, transform.localScale.z);
    }
}
