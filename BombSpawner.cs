using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{

    
    public List<GameObject> minions;
    public GameObject minionPrefab;
    public GameObject bombSpawnPos;
    protected float spawnTimer = 0f;
    protected float spawnDelay = 1f;


    private void Start()
    {
        this.minions = new List<GameObject>();
        this.bombSpawnPos = GameObject.Find("BombSpawnPos ");
        this.minionPrefab = GameObject.Find("BombPrefab");
       
        this.minionPrefab.SetActive(false);
    }
    private void Update()
    {

        this.Spawn();

        this.CheckMinionDead();
    }

    private void Spawn()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0;

        if (this.minions.Count >= 7) return;

        int index = this.minions.Count + 1;
        GameObject minion = Instantiate(this.minionPrefab);
        minion.name = "Bom #" + index;

        minion.transform.position = this.bombSpawnPos.transform.position;
        minion.gameObject.SetActive(true);

        this.minions.Add(minion);
    }

    void CheckMinionDead()
    {
        GameObject minion;
        for (int i = 0; i < this.minions.Count; i++)
        {
            minion = this.minions[i];
            if (minion == null) this.minions.RemoveAt(i);
        }
    }
   
}
