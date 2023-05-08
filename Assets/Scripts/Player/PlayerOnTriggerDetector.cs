using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnTriggerDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var trigger = collision.GetComponent<IOnTriggerable>();

        if (trigger != null)
            trigger.PlayerOnTriggerEnter();
       
        //collision.GetComponent<IOnTriggerable>().PlayerOnTriggerEnter();
    }
}