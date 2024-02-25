using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jump;

    private float Move;

    public Rigidbody2D rb;
    public Animator animator;

    public bool isJumping;
    public bool canMove;
    public static PlayerController instance;

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

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
         Move = Input.GetAxis("Horizontal");
         animator.SetFloat("speed", Mathf.Abs(Move));
         rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if(Move > 0)
         {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
         }
        if(Move <0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Lanterne.instance.lamp)
        {
            animator.SetTrigger("lampe");
        }
           







         if(Input.GetButtonDown("Jump") && isJumping == false)
         {
            rb.AddForce(new Vector2(rb.velocity.x, jump));        
         }
    }









    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }

}
