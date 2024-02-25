using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabeglise : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;

    bool isOndial, canDial;


    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (Input.GetKeyDown(KeyCode.E) && canDial)
            {
                Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
            }
    

            
            
    }

}
 



