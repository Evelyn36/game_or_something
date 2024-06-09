using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    public float refresh_time;
    public float range;

    private bool can_shoot = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            

        }

    }

    private IEnumerator shoot() 
    {
        Instantiate(bullet, gameObject.transform);
        yield return new WaitForSeconds(refresh_time);

    }

}
