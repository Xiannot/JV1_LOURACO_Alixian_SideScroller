using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite sp1, sp2;

      public void OnTriggerEnter2D(Collider2D collision)
      {
        if(collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
        }
        
        {
            GetComponent<SpriteRenderer>().sprite = sp2;
        }
    }
}