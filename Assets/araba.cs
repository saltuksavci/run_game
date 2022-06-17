using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araba : MonoBehaviour
{


    float hiz = 5;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        transform.Translate(0, 0, hiz * Time.deltaTime);
    }
}
