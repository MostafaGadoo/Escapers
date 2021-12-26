using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            FindObjectOfType<PlayerState>().TakeDamage(damage);
        }
    }
}
