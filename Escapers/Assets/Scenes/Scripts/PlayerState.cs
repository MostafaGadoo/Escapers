﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int health = 6;
    public int lives = 3;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immunityTime = 0f;
    private float immunityDuration = 1.5f;
    //public Text scoreUI;
    //public int CoinCollection;
    //public Slider healthUI;
    //public Gradient gradient;
    //public Image fill;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        //fill.color = gradient.Evaluate(1f);

    }

    // Update is called once per frame
    void Update()
    {
        //healthUI.value = health;
        //fill.color = gradient.Evaluate(healthUI.normalizedValue);

        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }

        }
        //scoreUI.text = "" + CoinCollection;
    }
    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            if (this.health < 0)
                this.health = 0;
            if (this.lives > 0 && this.health == 0)
            {
                //FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                Debug.Log("GameOver");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health: " + this.health.ToString());
            Debug.Log("Player Lives: " + this.lives.ToString());
        }
        PlayHitReaction();

    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
}
