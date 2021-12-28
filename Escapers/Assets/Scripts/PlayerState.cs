using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public int health = 9;
  
    public int damage = 3;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immunityTime = 0f;
    private float immunityDuration = 1.5f;
    public Animator anim;
    public Slider healthUI;
    public Gradient gradient;
    public Text LivesUI;
    public int Lives = 2;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
      

    }

    // Update is called once per frame
    void Update()
    {
        healthUI.value = health;
        

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
        LivesUI.text = "" + Lives;

    }
    public void LivesRem(int Lives)
    {
        this.Lives = this.Lives - Lives;
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
            if (this.Lives > 0 && this.health == 0)
            {
                //FindObjectOfType<levelManager>().RespawnPlayer();
                this.health = 9;
                this.Lives--;
            }
            else if (this.Lives == 0 && this.health == 0)
            {
                anim.SetTrigger("death");
                Debug.Log("GameOver");
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health: " + this.health.ToString());
            Debug.Log("Player Lives: " + this.Lives.ToString());
        }
        PlayHitReaction();

    }
    
    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    
}
