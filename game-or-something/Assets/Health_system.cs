using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_system : MonoBehaviour
{

    public int MaxHealth = 10;

    public int CurHealth;

    private void Start()
    {
        CurHealth = MaxHealth;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            CurHealth -= 1;


        }


    }

    private void FixedUpdate()
    {
        if (CurHealth <= 0)
        {
            Destroy(gameObject);

        }
    }


}
