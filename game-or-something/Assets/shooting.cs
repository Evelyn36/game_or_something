using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    public float refresh_time;
    public float range;
    public float bullet_speed;
    public float bullet_damage;
    private bool can_shoot = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && can_shoot)
        {
            StartCoroutine(shoot());

        }

    }

    private IEnumerator shoot() 
    {
        can_shoot = false;
        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation, null);
        yield return new WaitForSeconds(refresh_time);
        can_shoot=true;

    }

}
