using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Behaviour : MonoBehaviour
{

    public Transform[] spawnpoints;

    public GameObject[] PossibleEnemies;

    public int ActiveEnemies;

    public GameObject EnemyParent;

    void Start()
    {
        ActiveEnemies = 0;
        
    }



    private void Update()
    {
        if (EnemyParent.transform.childCount == 0)
        {

            ActiveEnemies = 0;
        }
    }

    public void FixedUpdate()
    {
     
        if (ActiveEnemies < 0){

            ActiveEnemies = 0;
        }

        if (ActiveEnemies == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                int randEnemy = Random.Range(0, PossibleEnemies.Length);
                int randSpawnPoint = Random.Range(0, spawnpoints.Length);


                ActiveEnemies++;


                Instantiate(PossibleEnemies[randEnemy], spawnpoints[randSpawnPoint].position, Quaternion.identity, EnemyParent.transform);

            }

            
            

            

        }



    }


    public void RemoveEnemy()
    {
       
        ActiveEnemies --;
       

    }


}
