using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private int attackDamage;

    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player) playerInRange = true;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == player) playerInRange = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0;
        playerHealth.TakeDamage(attackDamage);
    }
}
