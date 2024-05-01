using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnRange;
    [SerializeField] Transform player;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;
    public float minX, maxX, minY, maxY;
    private float _timeUntilNextSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        _timeUntilNextSpawn -= Time.deltaTime;

        if (_timeUntilNextSpawn <= 0 && distanceFromPlayer > SpawnRange && DataManager.Instance.activeEnemy <= 20 )
        {
            Instantiate(_enemyPrefab, new Vector3 ((transform.position.x + Random.Range(minX,maxX)), (transform.position.y + Random.Range(minY,maxY)), transform.position.z), Quaternion.identity);
            DataManager.Instance.activeEnemy++;
            SetTimeUntilSpawn();
        }
    }
    private void SetTimeUntilSpawn()
    {
        _timeUntilNextSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.position, SpawnRange);

    }
}
