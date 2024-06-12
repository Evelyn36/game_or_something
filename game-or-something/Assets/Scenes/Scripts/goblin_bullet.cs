
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class goblin_bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bullet_speed;
    public int bullet_damage;

    [SerializeField] private GameObject player;
 


    private Health_system Health;


   

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        Health = player.GetComponent<Health_system>();

        
        
    }


    void FixedUpdate()
    {
        rb.transform.Translate(Vector2.right * Time.deltaTime * bullet_speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Health = collision.collider.GetComponent<Health_system>();
            Health.CurHealth -= bullet_damage;
           

        }
       



        Destroy(gameObject);
        
        
    }






}