using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    public GameObject bloodHitEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().DamageEnemy(bulletDamage);
            CollisionEffect();
        }
        else if (collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossLifeController>().DamageEnemy(bulletDamage);
            CollisionEffect();
        }
        else
            Destroy(gameObject);
    }

    void CollisionEffect()
    {
        GameObject effect = Instantiate(bloodHitEffect, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        Destroy(effect, 10);
        Destroy(gameObject);
    }
}
