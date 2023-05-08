using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerItem : MonoBehaviour, IOnTriggerable
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerOnTriggerEnter()
    {
        PlayerHealth.playerHealth.Heal();
        audioSource.Play();
        Destroy(gameObject, 0.2f);
    }
}
