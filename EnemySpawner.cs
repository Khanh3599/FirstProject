using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    protected List<GameObject> enemies;
    protected int maxEnemy = 1;
    protected GameObject enemyPrefab;
    protected GameObject enemySpawnPos;

    protected float timer = 0f;
    protected float delay = 2f;

    private void Awake()
    {
        this.enemySpawnPos = GameObject.Find("EnemySpawnPos");
        this.enemyPrefab = GameObject.Find("EnemyPrefab");

        this.enemyPrefab.SetActive(false);
        this.enemies = new List<GameObject>();
    }

    private void Update()
    {
        this.Spawn();
        this.CheckDead();
    }

    protected virtual void Spawn() // Spawn enemy
    {

        if (PlayerCtrl.instance.damageReceiver.IsDead()) return;
        if (this.enemies.Count >= this.maxEnemy) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        GameObject enemy = Instantiate(this.enemyPrefab);
        enemy.transform.position = this.enemySpawnPos.transform.position;
        enemy.transform.parent = transform;  // -> transform = spawneer
        enemy.SetActive(true);

        this.enemies.Add(enemy);
    }

    void CheckDead()
    {
        GameObject enemy;
        for (int i = 0; i < this.enemies.Count; i++)
        {
            enemy = this.enemies[i];
            if (enemy == null) this.enemies.RemoveAt(i);
        }
    }
}
