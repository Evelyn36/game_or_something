using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordStuff : MonoBehaviour
{

    public GameObject Sword;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SwordSwing());
        }
    }

    IEnumerator SwordSwing()
    {
        Sword.GetComponent<Animator>().Play("SwordSwing");
        yield return new WaitForSeconds(1.0f);

    }
}

