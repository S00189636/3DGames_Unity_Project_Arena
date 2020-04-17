using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{

    public PickupState PickupState;
    public Weapon currentWeapon;
    public string FireButton = "Fire1";
    public Transform FirePoint;
    private int hitCounter = 0;
    void Update()
    {
        if (Input.GetButtonUp(FireButton))
        {
            PickupState =  GetComponent<Pickup>().pickupState;
            if (PickupState == PickupState.HasWeapon)
            {
                hitCounter++;
                currentWeapon = GetComponent<Pickup>().currentWeapon.GetComponent<Weapon>();
                currentWeapon.Fire(FirePoint.forward);
                //currentWeapon.Fire(CrosshairLandMark);
                if ( hitCounter >= currentWeapon.Durability)
                {
                    hitCounter = 0;
                    Destroy(currentWeapon.gameObject);
                    GetComponent<Pickup>().pickupState = PickupState.Empty;
                }
            }
        }
    }
}
