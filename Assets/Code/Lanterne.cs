using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Lanterne : MonoBehaviour
{

    
    public bool lamp = false;
    public Animator animator;
    public static Lanterne instance;

    private void Awake()
    {
        if(instance != null && instance !=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            lamp = true;
        }
    }
}