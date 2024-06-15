using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health_system : MonoBehaviour
{

    public int MaxHealth = 10;

    public int CurHealth;


    public movement Movement;


    public GameObject damageTextPrefab;
    public string damageText;

    public GameObject TextHolder;

    private void Start()
    {
        CurHealth = MaxHealth;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Movement.isDashing && collision.collider.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }


        if (collision.collider.tag == "Enemy")
        {
            TakeDamagePlayer(1);


        }


    }

    private void FixedUpdate()
    {
        if (CurHealth <= 0)
        {
            Destroy(gameObject);

        }
    }



    public void TakeDamagePlayer(int DamageAmount)
    {

        CurHealth -= DamageAmount;

        TextHolder.transform.rotation = Quaternion.identity;
        GameObject DamageText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity, TextHolder.transform);
        damageText = DamageAmount.ToString();
        DamageText.GetComponent<TextMeshPro>().SetText(damageText);
        DamageText.GetComponent<TextMeshPro>().color = Color.red;


    }


}
