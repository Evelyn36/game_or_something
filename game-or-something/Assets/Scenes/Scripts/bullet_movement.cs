
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject gun;
    private shooting shooting_script;
    private float bullet_speed;
    private float bullet_damage;
    private Enemy enemy;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        shooting_script = FindObjectOfType<shooting>();
        bullet_speed = shooting_script.bullet_speed;
        bullet_damage = shooting_script.bullet_damage;

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
        }

        Destroy(gameObject);
    }
}