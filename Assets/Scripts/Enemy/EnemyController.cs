using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health;
    public GameObject deathEffect;

    //Animator anim;
    private int currentHealth;

    private void Start()
    {
        //anim = GetComponent<Animator>();
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
            //anim.SetTrigger("Death");
            if(EnemySpawner.enemySpawner !=null) 
            {
                EnemySpawner.enemySpawner.EnemyKilled();
            }
            
            Destroy(gameObject);
        }
    }
}
