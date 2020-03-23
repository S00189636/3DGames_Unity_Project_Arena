using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Weapon : Collectable
{

    public float Damage { get; set; }
    protected Rigidbody rigidbody;
    protected virtual void Start()
    {
        this.PickupType = PickupType.Collectable;
        rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Fire(Vector3 direction)
    {

    }
}
