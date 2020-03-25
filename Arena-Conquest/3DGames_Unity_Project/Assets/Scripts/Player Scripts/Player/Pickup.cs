﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupState
{
    Empty,
    HasWeapon
}

public class Pickup : MonoBehaviour
{

    public Transform castStartPosition;
    public GameObject hand;
    public GameObject currentWeapon;
    public float castDistance = 50f;
    public PickupState pickupState = PickupState.Empty;
    public float xOffSet;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            // do the ray cast 
            PickUp();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(castStartPosition.position, (this.transform.forward /*- new Vector3(xOffSet, 0, 0)*/)  * castDistance);
    }

    private void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(castStartPosition.position, castStartPosition.forward /*- new Vector3(xOffSet,0,0)*/, out hit, castDistance))
        {
            Collectable collectable = hit.transform.gameObject.GetComponent<Collectable>();
            if (collectable == null) return;
            if (collectable.PickupType == PickupType.Collectable)
            {
                //if (pickupState == PickupState.HasWeapon) return;
                GameObject pickedUp = Instantiate(hit.transform.gameObject,hand.transform.position,hand.transform.rotation,hand.transform);
                Destroy(currentWeapon.gameObject);
                currentWeapon = pickedUp;
                pickupState = PickupState.HasWeapon;
                Destroy(hit.transform.gameObject);
            }
            else if(collectable.PickupType == PickupType.Consumable)
            {
                // use it 
            }
            
        }
    }
}
