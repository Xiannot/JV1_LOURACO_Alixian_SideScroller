using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;

    public bool boulangerie = false;

    public bool eglise = false;
    

   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (boulangerie == false)
        {
            boulangerie = true;
            Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
            
            
        }

    }
 

}

