using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    public float refresh_time;
    public float range;
    public float bullet_speed;
    public float bullet_damage;
    public int bullet_clip_amount;
    public float reload_time;
    public float bullet_knockback;

    private bool can_shoot = true;
    public bool reloading = false;
    public int bullets;

    public UnityEvent OnBegin, OnDone;

    private void Start()
    {
        bullets = bullet_clip_amount;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && can_shoot && reloading == false)
        {
            StartCoroutine(shoot());

        }

    }

    private IEnumerator shoot() 
    {
        can_shoot = false;
        bullets -= 1;
        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation, null);
        yield return new WaitForSeconds(refresh_time);
        if (bullets <= 0)
        {
            StartCoroutine(reload());
        }
        can_shoot=true;

    }


    private IEnumerator reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reload_time);
        bullets = bullet_clip_amount;
        reloading = false;

    }




}
