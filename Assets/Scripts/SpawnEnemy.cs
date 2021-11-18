using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform spawnSite;

    [SerializeField]
    private float initialWaitSec;

    [SerializeField]
    private float frequencySec;

    [SerializeField]
    private int maxEnemies;

    [SerializeField]
    private Transform target;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), initialWaitSec, frequencySec);
    }

    private void Spawn()
    {
        // Remove all destroyed enemies
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }

        // Do not spawn if there are already too many enemies
        if (enemies.Count >= maxEnemies)
            return;
        
        var newEnemy = Instantiate(enemyPrefab, spawnSite.position, spawnSite.rotation);
        var seek = newEnemy.GetComponent<Seek>();
        seek.target = target;

        enemies.Add(newEnemy);
    }
}
