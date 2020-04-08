﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public PickupState PickupState;
    public Weapon currentWeapon;
    public string FireButton = "Fire1";
    public Transform FirePoint;
    void Update()
    {
        if (Input.GetButton(FireButton))
        {
            PickupState =  GetComponent<Pickup>().pickupState;
            if (PickupState == PickupState.HasWeapon)
            {
                currentWeapon = GetComponent<Pickup>().currentWeapon.GetComponent<Weapon>();
                currentWeapon.Fire(FirePoint.forward);
                Destroy(currentWeapon);
                GetComponent<Pickup>().pickupState = PickupState.Empty;
            }
        }
    }
}
