using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class box : MonoBehaviour
{

    public CameraFollow hauteur;

    public float yOffsete = 0.5f;

    public float cam = 0.7f;
    void Start(){
        
        Camera.main.orthographicSize = cam;

        hauteur.yOffset = yOffsete;

        
        

        
  
    
        
    }
}