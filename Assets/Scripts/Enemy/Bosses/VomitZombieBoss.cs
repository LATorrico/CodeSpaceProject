using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class VomitZombieBoss : MonoBehaviour
{
    [SerializeField] private float fireballSpeed;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject fireballVomit;
    [SerializeField] private float readyForNextShot;

    Animator anim;
    AudioSource vomitShotAudio;
    private float timer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        vomitShotAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > readyForNextShot)
        {
            timer = 0;
            anim.SetTrigger("Attack");
            Invoke("VomitShot", 0.1f);
        }
    }

    void VomitShot()
    {
        vomitShotAudio.Play();
        GameObject fireBall = Instantiate(fireballVomit, shotPoint.position, shotPoint.rotation);
        fireBall.GetComponent<Rigidbody2D>().AddForce(fireBall.transform.up * fireballSpeed);
        
    }
}
