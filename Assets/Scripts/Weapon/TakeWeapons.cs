using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapons : MonoBehaviour, IOnTriggerable
{
    AudioSource takeWeaponAudio;
    [SerializeField] private GameObject weaponHolder;

    private void Start()
    {
        takeWeaponAudio = GetComponent<AudioSource>();
    }

    public void PlayerOnTriggerEnter()
    {
        takeWeaponAudio.Play();
        weaponHolder.GetComponent<WeaponSwitch>().enabled = true;
        Destroy(gameObject, 0.1f);
    }
}
