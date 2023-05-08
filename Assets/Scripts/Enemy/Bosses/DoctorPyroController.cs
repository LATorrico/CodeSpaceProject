using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorPyroController : MonoBehaviour
{
    Animator anim;
    AudioSource fireShotAudio;

    [SerializeField] private float fireballSpeed;
    [SerializeField] private Transform[] multiShotPoints;
    [SerializeField] private GameObject fireball;
    [SerializeField] private float readyForNextShot;

    private float timer;

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    [SerializeField] private int limitOfEnemies;
    [SerializeField] private int enemyCount = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        fireShotAudio = GetComponent<AudioSource>();
        StartCoroutine("Spawner");
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > readyForNextShot)
        {
            timer = 0;
            anim.SetTrigger("Attack");
            Invoke("MultiFireShot", 0.1f);
        }
    }

    void MultiFireShot()
    {
        fireShotAudio.Play();
        foreach (Transform shotPoint in multiShotPoints)
        {
            GameObject fireBall = Instantiate(fireball, shotPoint.position, shotPoint.rotation);
            fireBall.GetComponent<Rigidbody2D>().AddForce(fireBall.transform.up * fireballSpeed);
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
}
