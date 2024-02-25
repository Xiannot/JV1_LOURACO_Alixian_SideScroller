using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currenHealth { get; private set;}
    private bool dead;
    private Animator anim;

    private void Awake()
    {
        currenHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currenHealth = Mathf.Clamp(currenHealth - _damage, 0, startingHealth);
        currenHealth -= _damage;

        if (currenHealth >0)
        {

        }
        else{
            if (!dead)
            {
                anim.SetTrigger("mort");
               
            }

        }
    }

    public void AddHealth(float _value)
    {
        currenHealth = Mathf.Clamp(currenHealth +_value, 0, startingHealth);
    }
        public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(1);
        }
    }
}
