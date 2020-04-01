using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : Weapon
{
    public float ThrowPower;
    public GameObject PrjectailPrefab;
    public override void Fire(Vector3 direction)
    {
        GameObject Prjectail = Instantiate(PrjectailPrefab,transform.position,transform.rotation);

        Prjectail.GetComponent<Rigidbody>().useGravity = true;
        Prjectail.GetComponent<Projectile>().Shooter = this.gameObject;
        Prjectail.GetComponent<Projectile>().direction = direction;
        Prjectail.GetComponent<Projectile>().Speed = ThrowPower;
        Prjectail.GetComponent<Projectile>().Damage = Damage;
        Destroy(this.gameObject);
    }

}
