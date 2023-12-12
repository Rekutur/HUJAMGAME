using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    [SerializeField] GameObject target;
    public float bulletspeed;
    Rigidbody2D bulletRB;
    public GameObject bulletImpactEffect;
    public float bulletDamage;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * bulletspeed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        switch (collision.tag)
        {
            case "Player":
                collision.GetComponent<PlayerManager>().DealDamage(bulletDamage);
                Destroy(gameObject);
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
}