using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public PickupState PickupState;
    public Weapon currentWeapon;
    public string FireButton = "Fire1";
    void Update()
    {
        if (Input.GetButtonUp(FireButton))
        {
            PickupState =  GetComponent<Pickup>().pickupState;
            if (PickupState == PickupState.HasWeapon)
            {
                currentWeapon = GetComponent<Pickup>().currentWeapon.GetComponent<Weapon>();
                currentWeapon.Fire((Camera.main.transform.forward + (Vector3.up * Camera.main.transform.rotation.x)));
                Destroy(currentWeapon);
                GetComponent<Pickup>().pickupState = PickupState.Empty;
            }
        }
    }
}
