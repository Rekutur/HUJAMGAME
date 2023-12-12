using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public float bulletDamage;
    public float lifeTime = 2f;
    public Rigidbody2D rb;
    public GameObject bulletImpactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(despawnCountDown());
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        switch (collision.tag)
        {
            case "Enemy":
                Debug.Log("Hit");
                collision.GetComponent<EnemyManager>().GetDamage(bulletDamage);
                Destroy(gameObject);
                break;
            case "Player":
                Debug.Log("Collided with player");
                break;
            case "Destructible":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
    public IEnumerator despawnCountDown()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
