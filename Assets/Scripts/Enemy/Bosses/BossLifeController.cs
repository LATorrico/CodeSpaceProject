using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLifeController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject bossRoomController;
    public GameObject deathEffect;

    Animator anim;
    private int currentHealth;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = health;
    }

    private void Update()
    {
        Death();
    }

    public void DamageEnemy(int damage)
    {
        if (currentHealth <= 0)
            return;
        currentHealth -= damage;
    }

    void Death()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1);
            Instantiate(item, transform.position, Quaternion.identity);
            //anim.SetTrigger("Death");
            //if (BossRoomController.bossRoomController != null)
            //{
            //    BossRoomController.bossRoomController.BossKilled();
            //}
            bossRoomController.GetComponent<BossRoomController>().BossKilled();

            Destroy(gameObject);
        }
    }
}