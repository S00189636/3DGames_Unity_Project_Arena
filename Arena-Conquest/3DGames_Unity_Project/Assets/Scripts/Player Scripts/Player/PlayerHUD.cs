
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public float imageDamageTime = 0.5f;
    public Image TakingDamageImage;
    public Health playerHealth;
    public TextMeshProUGUI KeillsTextMesh;
    Weapon CurrentWeapon;
    int kills;

    private void OnEnable()
    {
        LevelManager.OnEnemyDied += PlayerHUD_OnEnemyDied;
        playerHealth.OnTakingDamage += PlayerHUD_OnTakingDamage;
        //playerHealth.OnDeath += PlayerHealth_OnDeath;
    }

    //private void PlayerHealth_OnDeath()
    //{
    //    throw new System.NotImplementedException();
    //}

    private void PlayerHUD_OnTakingDamage(float amount)
    {
        CancelInvoke("DisableDamageImage");
        TakingDamageImage.enabled = true;
        Invoke("DisableDamageImage", imageDamageTime * amount);

        //update healthbar
        print("Player Taking damag : "+amount);

    }

    private void PlayerHUD_OnEnemyDied(GameObject gameObject)
    {
        kills++;
        KeillsTextMesh.text = "Kills: " + kills;
    }
    void DisableDamageImage()
    {
        TakingDamageImage.enabled = false;
    }



}
