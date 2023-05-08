using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private GameObject failMissionPanel;

    public static PlayerHealth playerHealth;

    AudioSource damageAudio;

    private void Start()
    {
        playerHealth = this;
        damageAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckHearts();
    }

    void CheckHearts()
    {
        if (health <= 0)
            Death();

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        damageAudio.Play();
        health -= damage;
    }

    public void Heal()
    {
        if (health == numOfHearts)
            return;

        health++;
    }

    public void HeartsIncrease()
    {
        numOfHearts++;
    }

    void Death()
    {
        Time.timeScale = 0f;
        failMissionPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
