using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Text : MonoBehaviour
{


   public void DestroyParent()
    {
        GameObject parent = gameObject;
        Destroy(parent);
    }



}
