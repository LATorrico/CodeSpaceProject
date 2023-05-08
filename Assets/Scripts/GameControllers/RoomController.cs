using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using UnityEngine;

public class RoomController : MonoBehaviour, IOnTriggerable
{
    public GameObject enemySpawner;
    [SerializeField] GameObject doors;
    Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    public void PlayerOnTriggerEnter()
    {
        doors.GetComponent<DoorController>().CloseDoor();

        enemySpawner.SetActive(true);
        enemySpawner.GetComponent<EnemySpawner>().StartCoroutine("Spawner");
        Destroy(col);
    }
}