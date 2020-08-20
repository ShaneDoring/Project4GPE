using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public float enemySensePlayer;
    public Vector3 targetPosition;
    public string enemyState = "Patrol";
    public float moveSpeed;
    
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == "Patrol")
        {
            //Do the patrol behavior
            Patrol();
            //check fro transition

        }
        else if (enemyState == "Seek")
        {
            //Do the seek behavior
            Seek();
            //check for transitions
        }
    }

    void Seek()
    {
        

    }


    private void Patrol()
    {
   
  
    }
}
