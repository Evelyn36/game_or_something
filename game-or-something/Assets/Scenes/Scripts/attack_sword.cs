using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_sword : MonoBehaviour
{

    [SerializeField] private GameObject sword;


    private List<GameObject> SwordList;
    
    private GameObject Sword;

    private bool isAttacking = false;

    private void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isAttacking == false)
        {
            
            Sword = Instantiate(sword, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            StartCoroutine(wait(Sword));
        }

       
    }

    private IEnumerator wait(GameObject Sword)
    {
        
        isAttacking = true;
        
        yield return new WaitForSeconds(0.25f);
        
        isAttacking = false;
    }


}
