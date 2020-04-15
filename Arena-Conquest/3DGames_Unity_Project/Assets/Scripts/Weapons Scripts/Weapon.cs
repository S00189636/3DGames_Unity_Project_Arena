using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collectable
{

    public float Damage;
    protected Rigidbody body { get { return GetComponent<Rigidbody>(); } }
    protected virtual void Start()
    {
        this.PickupType = PickupType.Collectable;
    }

    public virtual void Fire(Vector3 direction)
    {

    }

}
