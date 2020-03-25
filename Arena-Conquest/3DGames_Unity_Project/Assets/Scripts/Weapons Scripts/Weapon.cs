using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collectable
{
    
    public float Damage;
    protected Rigidbody body;
    protected virtual void Start()
    {
        this.PickupType = PickupType.Collectable;
        body = GetComponent<Rigidbody>();
    }

    public virtual void Fire(Vector3 direction)
    {

    }
}
