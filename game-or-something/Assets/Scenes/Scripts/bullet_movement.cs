
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class bullet_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject gun;
    private shooting shooting_script;
    private float bullet_speed;
    private float bullet_damage;
    private float bullet_knockback;
    private Enemy enemy;
    private float knockback_strength;
    
   

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        shooting_script = FindObjectOfType<shooting>();
        bullet_speed = shooting_script.bullet_speed;
        bullet_damage = shooting_script.bullet_damage;
        
        knockback_strength = shooting_script.bullet_knockback;


    }

    void FixedUpdate()
    {
        rb.transform.Translate(Vector2.right * Time.deltaTime * bullet_speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            enemy = collision.collider.GetComponent<Enemy>();
            enemy.TakeDamage(bullet_damage);


            GameObject EEnemy = collision.collider.gameObject;

            knockback_feedback knockback_script = collision.collider.GetComponent<knockback_feedback>();

            if (shooting_script.bullets == 0)
            {
                knockback_script.PlayFeedback(gameObject, (knockback_strength) * 2);
            }
            else
            {
                knockback_script.PlayFeedback(gameObject, knockback_strength);
            }


            

            
            
           

        }


        Destroy(gameObject);
    }


   



}