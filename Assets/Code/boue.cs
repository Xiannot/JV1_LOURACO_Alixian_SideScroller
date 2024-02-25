using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class boue : MonoBehaviour
{
    public bool danslaboue = false;


    public float deplacementboue = 50f;
    public float deplacementerre = 100f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            danslaboue = true;
            PlayerController.instance.speed = deplacementboue; 
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            danslaboue = false;
            PlayerController.instance.speed = deplacementerre; 
        }

    }
}
