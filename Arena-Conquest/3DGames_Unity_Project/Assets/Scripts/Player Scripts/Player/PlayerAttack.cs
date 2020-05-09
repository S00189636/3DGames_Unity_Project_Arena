using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{

    public PickupState PickupState;
    public Weapon currentWeapon;
    public string FireButton = "Fire1";
    public string DropWeaponButton = "Fire2";
    public Transform FirePoint;
    private int hitCounter = 0;
    public Crosshair Crosshair;
    private Vector3 hitPos { get { return Crosshair.raycastHit.point == Vector3.zero ? FirePoint.up : (Crosshair.raycastHit.point - FirePoint.position).normalized; } }
    void Update()
    {
        PickupState = GetComponent<Pickup>().pickupState;
        if (Input.GetButtonUp(FireButton))
        {
            if (PickupState == PickupState.HasWeapon)
            {
                hitCounter++;
                currentWeapon = GetComponent<Pickup>().currentWeapon.GetComponent<Weapon>();
                //print($"PlayerAttack: hit pos: {hitpos}");
                currentWeapon.Fire(hitPos, FirePoint.rotation);
                //currentWeapon.Fire(CrosshairLandMark);
                if (hitCounter >= currentWeapon.Durability)
                {
                    DropWeapon(currentWeapon.destroyAfter);
                }
            }
        }

        if (Input.GetButtonUp(DropWeaponButton))
        {
            if (PickupState == PickupState.HasWeapon)
            {
                DropWeapon();
            }
        }
    }

    private void DropWeapon()
    {
        DropWeapon(0);
    }
    private void DropWeapon(float destroyAfter)
    {
        hitCounter = 0;
        Destroy(currentWeapon.gameObject, destroyAfter);
        GetComponent<Pickup>().pickupState = PickupState.Empty;
    }
}
