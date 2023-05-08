using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomController : MonoBehaviour, IOnTriggerable
{
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject doors;
    [SerializeField] private int bossesOnBossRoom;

    public int bossKillCount;
    Collider2D col;
    AudioSource killEnemyAudio;

    public static BossRoomController bossRoomController;

    private void Start()
    {
        bossRoomController = this;
        col = GetComponent<Collider2D>();
        killEnemyAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckBossDie();
    }

    public void PlayerOnTriggerEnter()
    {
        doors.GetComponent<DoorController>().CloseDoor();

        BossInstantiate();
        Destroy(col);
    }

    void BossInstantiate()
    {
        boss.SetActive(true);
        //var _boss = Instantiate(boss, spawnPoint.position, Quaternion.identity);
        //_boss.transform.parent = gameObject.transform;
    }

    void CheckBossDie()
    {
        if(bossKillCount == bossesOnBossRoom)
        {
            BossDeath();
        }
            
    }

    void BossDeath()
    {
        doors.GetComponent<DoorController>().OpenDoor();
        Destroy(doors);
        Destroy(gameObject);
    }

    public void BossKilled()
    {
        //killEnemyAudio.Play();
        bossKillCount++;
    }
}
