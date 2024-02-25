using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    private float Move;
    public Transform[] waypoints;

    private Transform target;
    private int desPoint = 0;
   

    void Start()
    {
        target = waypoints[0];
        

    }

    void Update()
    {
    

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            desPoint = (desPoint + 1) % waypoints.Length;
            target = waypoints[desPoint];

           

          

        }
    }
}