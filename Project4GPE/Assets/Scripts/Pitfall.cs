using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
 
    private void OnTriggerExit2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);
        GameManager.instance.playerLives--;
       
    }


}
