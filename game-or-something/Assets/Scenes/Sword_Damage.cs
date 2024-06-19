using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Damage : MonoBehaviour
{

    private Enemy enemy;

    private GameObject player;
    private attack_sword sword_script;

    public float SwordDamage;
    public float knockback_strength;

    private Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sword_script = player.GetComponent<attack_sword>();
        animate = gameObject.GetComponentInParent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(SwordDamage);
            knockback_feedback knockback_script = collision.GetComponent<knockback_feedback>();
            knockback_script.PlayFeedback(gameObject, knockback_strength);
        }

    }
}
