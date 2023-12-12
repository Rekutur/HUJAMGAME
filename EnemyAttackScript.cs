using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public GameObject bullet;
    public GameObject namlu;
    private Transform player;
    public float fireRate = 1f;
    private float fireCD;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }
    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange )
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        } else if (distanceFromPlayer <= shootingRange && fireCD < Time.time)
        {
            Instantiate(bullet, namlu.transform.position, Quaternion.identity);
            fireCD = Time.time + fireRate;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }
}
