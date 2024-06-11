using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_sword : MonoBehaviour
{

    [SerializeField] private GameObject sword;


    private List<GameObject> SwordList;

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAttacking == false)
        {
            StartCoroutine(wait(Instantiate(sword, gameObject.transform.position, Quaternion.identity, gameObject.transform)));

        }
    }

    private IEnumerator wait(GameObject Sword)
    {
        
        isAttacking = true;
        yield return new WaitForSeconds(0.2f);
        Destroy(Sword);
        isAttacking = false;
    }


}
