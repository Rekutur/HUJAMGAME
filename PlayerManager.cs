using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float maximumHealth;
    public float maxHealth = 40;
    public float health = 40;
    public Slider healthSlider;
    public bool isDead;
    public bool hasShuriken, hasShotGun, hasLaserGun, hasMiniGun, hasLaserSword, hasGreatSword, hasDarkSword;
    [SerializeField] MenuManagerScript menuManager;
    [SerializeField] MoneyDisplay moneyDisplay;
    [SerializeField] AudioSource dieSound, pickupSound, hurtSound;
    public bool hasKey1, hasKey2, hasKey3;

    public GameObject[] Guns;
    private int currentGun = 0;

    public void SetGun(int index)
    {
        if (currentGun != -1)
            Guns[currentGun].SetActive(false);
            currentGun = index;
            Guns[index].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }
    private void Update() //Handles equipping the weapons if the player has picked them up beforehand and updates the camera view range.
    {
        if (Input.GetKeyDown("3") && hasLaserGun)
        {
            SetGun(2);
        }
        else if (Input.GetKeyDown("2") && hasShotGun)
        {
            SetGun(1);
        }
        else if (Input.GetKeyDown("4") && hasShuriken)
        {
            SetGun(3);
        }
        else if (Input.GetKeyDown("5") && hasMiniGun)
        {
            SetGun(4);
        }
        else if (Input.GetKeyDown("1")) //pistol
        {
            SetGun(0); 
        }
        else if (Input.GetKeyDown("6")&& hasLaserSword)
        {
            SetGun(5);
        }
        else if (Input.GetKeyDown("7")&& hasGreatSword)
        {
            SetGun(6);
        }
        else if (Input.GetKeyDown("8")&& hasDarkSword)
        {
            SetGun(7);
        }
        maximumHealth = maxHealth + (DataManager.Instance.END_stat * 10);
    }

    public void DealDamage(float damagedealt) //Gets the damagedealt variable of the enemy and deals damage to player.
    {
        if ((health - damagedealt) >= 0)
        {
            hurtSound.Play();
            health -= damagedealt;
        }
        else if ((health -= damagedealt) <= 0)
        {
            health = 0;
            Die();
        }
        healthSlider.value = health;
    }
    void Die()
    {
        if (health <= 0)
        {
            isDead = true;
            DataManager.Instance.Lose();
            menuManager.Lose();
            dieSound.Play();
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup")) //Handles object gathering.
        {
            switch (other.name)
            {
                case ("Credits" + "(Clone)"):
                    Destroy(other.gameObject);
                    DataManager.Instance.credits += Random.Range(1, 10);
                    moneyDisplay.UpdateMoney();
                    break;
                case ("HealthDrop" + "(Clone)"):
                    if (health <= (maximumHealth - 10)) { health += 10; } else { health = maximumHealth; }
                    Destroy(other.gameObject);
                    healthSlider.value = health;
                    break;
                case ("AmmoDrop" + "(Clone)"):
                    DataManager.Instance.ammoPistol += 30;
                    DataManager.Instance.ammoLaser += 30;
                    DataManager.Instance.ammoShotty += 30;
                    DataManager.Instance.ammoShuriken += 30;
                    DataManager.Instance.ammoMinigun += 30;
                    DataManager.Instance.LoadData();
                    Destroy(other.gameObject);
                    break;
                case ("Key1" + "(Clone)"):
                    hasKey1 = true;
                    Destroy(other.gameObject);
                    break;
                case ("Key2" + "(Clone)"):
                    hasKey2 = true;
                    Destroy(other.gameObject);
                    break;
                case ("Key3" + "(Clone)"):
                    hasKey3 = true;
                    Destroy(other.gameObject);
                    break;
            }
            pickupSound.Play();
        }
        if (other.gameObject.CompareTag("WeaponPickup"))
        {
            switch (other.name)
            {
                case ("LaserGun" + "(Clone)"):
                    Destroy(other.gameObject);
                    hasLaserGun = true;
                    DataManager.Instance.ammoLaser += 30;
                    break;
                case ("ShotGun" + "(Clone)"):
                    Destroy(other.gameObject);
                    hasShotGun = true;
                    DataManager.Instance.ammoShotty += 30;
                    break;
                case ("Shuriken" + "(Clone)"):
                    Destroy(other.gameObject);
                    hasShuriken = true;
                    DataManager.Instance.ammoShuriken += 30;
                    break;
                case ("Minigun" + "(Clone)"):
                    Destroy(other.gameObject);
                    hasMiniGun = true;
                    DataManager.Instance.ammoMinigun += 100;
                    break;
                case ("LaserSword" + "(Clone)"):
                    Destroy(other.gameObject);
                    hasLaserSword = true;
                    break;
                case ("GreatSword" + "(Clone)"):
                    Destroy(other.gameObject);
                    hasGreatSword = true;
                    break;
                case ("DarkSword"+ "(Clone)"):
                    Destroy(other.gameObject);
                    hasDarkSword = true;
                    break;
            }
            pickupSound.Play();
        }
    }
}
