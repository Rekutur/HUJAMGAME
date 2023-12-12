using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public int SwingDamage = 15;
    public GameObject bulletImpactEffect;
    [SerializeField] GameObject playScreen;
    [SerializeField] Animation swinger;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && playScreen.gameObject.activeInHierarchy)
        {
            swinger = gameObject.GetComponent<Animation>();
            swinger.Play("SwingDamage");
        }
    }
        void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                Debug.Log("Hit");
                collision.GetComponent<EnemyManager>().GetDamage(SwingDamage);
                break;
            case "Player":
                Debug.Log("Collided with player");
                break;
            case "Bullet":
                Destroy(collision.gameObject);
                Instantiate(bulletImpactEffect, transform.position, transform.rotation);
                break;
        }
    }
}
