using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public GameObject weaponDrop, healthDrop, ammoDrop, moneyDrop;
    public string enemyType;
    [SerializeField] AudioSource dieSound;
    [SerializeField] MenuManagerScript menuManager;

    //public Slider healthSlider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("UFO");
        if (collision.tag == "Bullet")
        {
            Debug.Log("Shot");
            GetDamage(collision.GetComponent<BulletScript>().bulletDamage);
        }
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
            Die();
            DataManager.Instance.activeEnemy--;
        }
    }
    void Die()
    {
        if (health <= 0)
        {
            dieSound.Play();
            StartCoroutine(LootDropCalculator());
        }
        if(enemyType == "Lord")
        {
            menuManager.RollCredits();
        }
    }
    public IEnumerator LootDropCalculator()
    {
        int lootRoll = Random.Range(0, 15);
        if (lootRoll <= 1) Instantiate(healthDrop, this.transform.position, this.transform.rotation); else
        if (lootRoll > 2 && lootRoll < 7) Instantiate(moneyDrop, this.transform.position, this.transform.rotation); else
        if (lootRoll > 7 && lootRoll < 13) Instantiate(weaponDrop, this.transform.position, this.transform.rotation); else
        if (lootRoll > 13) Instantiate (weaponDrop, this.transform.position, this.transform.rotation); else
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }

}
