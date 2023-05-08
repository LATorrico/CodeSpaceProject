using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionComplete : MonoBehaviour, IOnTriggerable
{
    [SerializeField] GameObject missionCompletePanel;
    [SerializeField] GameObject player;
    public void PlayerOnTriggerEnter()
    {
        Time.timeScale = 0f;
        missionCompletePanel.SetActive(true);
        player.SetActive(false);
    }
}
