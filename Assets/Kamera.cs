using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform takip_edilen_kup;
   
    
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, takip_edilen_kup.position, Time.deltaTime * 1.5f);
        
    }
}
