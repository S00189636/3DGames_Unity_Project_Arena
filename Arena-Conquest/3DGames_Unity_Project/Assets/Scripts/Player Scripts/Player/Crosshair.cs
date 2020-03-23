using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Crosshair : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public Transform CameraTransform;
    public Color EnemyLockColour = Color.red;
    public Color normalColour = Color.red;
    Image crosshairImage;
    RaycastHit raycastHit;
    // Start is called before the first frame update
    void Start()
    {
        crosshairImage = GetComponent<Image>();
        crosshairImage.color = normalColour;
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out raycastHit))
        {
            if (raycastHit.transform.tag.Equals(enemyTag))
                crosshairImage.color = EnemyLockColour;
            else
                crosshairImage.color = normalColour;
        }
        else crosshairImage.color = normalColour;
    }
    private void OnDrawGizmos()
    {
        if (crosshairImage != null)
        {
            Gizmos.color = crosshairImage.color;
            Gizmos.DrawLine(transform.parent.position, raycastHit.point);
        }

    }
}
