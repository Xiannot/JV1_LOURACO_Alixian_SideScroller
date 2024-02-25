using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public Animator myAnimator;

    const string patrolTrigger = "patrolTrigger";

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            myAnimator.SetTrigger(patrolTrigger);
        }
        
    }
      public void OnTriggerEnter2D(Collider2D collision)
      {
        if(collision.CompareTag("Player"))
        {
            myAnimator.SetTrigger(patrolTrigger);
        }
      }
    
}
