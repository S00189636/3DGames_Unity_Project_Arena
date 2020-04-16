using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Throwable
}

public class Weapon : Collectable
{

    public float Damage;
    protected Rigidbody body { get { return GetComponent<Rigidbody>(); } }

    public int Durability = 1;

    public WeaponType WeaponType;
    protected virtual void Start()
    {
        this.PickupType = PickupType.Collectable;
    }

    public virtual void Fire(Vector3 direction)
    {

    }

}
