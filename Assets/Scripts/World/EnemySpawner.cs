using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : WorldObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 4f;
    [SerializeField] private int maxEnemies = 2;
    [SerializeField] private float respawnDelay = 5f;

    private List<EntityBase> _enemies = new List<EntityBase>();

    private float _timer;
    private int _currentEnemies = 0;

    public void Initialize()
    {
        ClearLevel();
        _timer = spawnInterval;
        _currentEnemies = 0;
    }

    protected override void LocalUpdate()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0 && _currentEnemies < maxEnemies)
        {
            SpawnEnemy();
            _timer = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform).GetComponent<EntityBase>();
        newEnemy.transform.localPosition = Vector3.zero;
        newEnemy.Initialize(0, 0, 0);
        _enemies.Add(newEnemy);
        _currentEnemies++;
        newEnemy.GetComponent<Enemy>().OnDeath += EnemyDied;
    }

    private void EnemyDied(EntityBase enemy)
    {
        _enemies.Remove(enemy);
        enemy.OnDeath -= EnemyDied;
        _currentEnemies--;
        StartCoroutine(RespawnEnemyAfterDelay(respawnDelay));
        enemy.Die();
    }

    private IEnumerator RespawnEnemyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (_currentEnemies < maxEnemies)
        {
            SpawnEnemy();
        }
    }
    
    private void ClearLevel()
    {
        if(_enemies.Count <= 0)
            return;
        
        for (int i = _enemies.Count - 1; i >=0; i--)
        {
            _enemies[i].OnDeath -= EnemyDied;
            Destroy(_enemies[i].gameObject);
        }
    }
}