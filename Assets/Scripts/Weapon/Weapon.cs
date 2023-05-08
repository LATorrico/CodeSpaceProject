using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;
    float readyForNextShot;
    public GameObject fireFlash, bullet;
    public Transform[] shotPoints;
    public Transform fireShot;
    AudioSource shootingAudio;

    private void Start()
    {
        shootingAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            if (Time.time > readyForNextShot)
            {
                shootingAudio.Play();
                readyForNextShot = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        foreach (Transform shotPoint in shotPoints)
        {
            GameObject bulletsIns = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            bulletsIns.GetComponent<Rigidbody2D>().AddForce(bulletsIns.transform.up * bulletSpeed);
            Destroy(bulletsIns, 3);
        }
        GameObject fireIns = Instantiate(fireFlash, fireShot.position, fireShot.rotation);
        Destroy(fireIns, 0.05f);
    }
}
