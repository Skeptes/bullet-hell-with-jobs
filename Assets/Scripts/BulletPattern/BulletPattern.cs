using System;
using UnityEngine;

public class BulletPattern : MonoBehaviour
{
    [HideInInspector] public Vector3 Direction;
    public float Speed = 5;

    virtual public Transform ComputeNextPos(Transform trans)
    {
        trans.position += Direction * Speed * Time.deltaTime;
        return trans;
    }

    virtual public void OnDeath()
    {

    }
}
