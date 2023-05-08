using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    [SerializeField] private int limitOfEnemies;
    [SerializeField] private int enemyCount = 0;
    [SerializeField] private int enemyKillCount;
    [SerializeField] private GameObject doors;
    [SerializeField] private GameObject roomController;

    public static EnemySpawner enemySpawner;
    AudioSource killEnemyAudio;

    private void Start()
    {
        enemySpawner = this;
        killEnemyAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (enemyKillCount == limitOfEnemies)
        {
            doors.GetComponent<DoorController>().OpenDoor();
            Destroy(roomController);
            Destroy(doors);
            Destroy(gameObject);
        }
    }

    public IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (limitOfEnemies > enemyCount)
        {
            yield return wait;
            int enemy = Random.Range(0, enemies.Length);
            int spawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemies[enemy], spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation);
            enemyCount++;
        }
    }

    public void EnemyKilled()
    {
        killEnemyAudio.Play();
        enemyKillCount++;
    }
}
