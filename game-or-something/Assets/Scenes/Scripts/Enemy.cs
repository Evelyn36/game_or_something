using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] float moveSpeed = 1f;


    Rigidbody2D rb;
     public Transform target;
    Vector2 moveDirection;

    private Vector3 direction;

    public bool inrange = false;


    public GameObject damageTextPrefab;
    public string damageText;

    public GameObject TextHolder;

    public GameObject FreezeManager;
    private FreezeFrames Freeze_script;

    public GameObject Spawners;
    private Spawning_Behaviour Spawning_script;

    private bool EnemyRemoved = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Freeze_script = FreezeManager.GetComponent<FreezeFrames>();
        Mathf.Clamp(health, 0, maxHealth);
        

    }
    void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
        Spawners = GameObject.Find("Enemy Spawners");
        Spawning_script = Spawners.GetComponent<Spawning_Behaviour>();

    }

    private void Update()
    {
        
        if (target)
        {
            direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }

    }

    private void FixedUpdate()
    {
        
        //if they're stunned (by a bullet) then they stop moving
        if (target && inrange == false)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
       



            

    }


    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage Amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is Now: {health}");


        Freeze_script.timeoffreeze = 0.05f;
        Freeze_script.FreezeTime();

        TextHolder.transform.rotation = Quaternion.identity;


        

        GameObject DamageText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity, TextHolder.transform);
        damageText = damageAmount.ToString();

        DamageText.GetComponent<TextMeshPro>().SetText(damageText);

        if (health <= 0 && !EnemyRemoved)
        {

            Spawning_script = Spawners.GetComponent<Spawning_Behaviour>();
            Spawning_script.RemoveEnemy();
            EnemyRemoved = true;
            

            Destroy(gameObject);
            

            OnEnemyKilled?.Invoke(this);
        }

    }

    



}
