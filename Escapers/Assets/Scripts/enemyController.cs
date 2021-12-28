using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
    public int health = 16;
    public int lives = 3;
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;
    public Slider healthUI;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthUI.value = health;
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    public void TakeDamage1(int damage)
    {
        this.health = this.health - damage;
        if (this.health < 0)
                this.health = 0;
            if (this.lives > 0 && this.health == 0)
            {
                FindObjectOfType<levelManager>().RespawnPlayer();
                this.health = 16;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
               
                Debug.Log("winner");
                Destroy(this.gameObject);
            }
            Debug.Log("Big Boss Health: " + this.health.ToString());
            Debug.Log("Big Boss Lives: " + this.lives.ToString());
        }
       

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerState>().TakeDamage(damage);
        }
    }
}
