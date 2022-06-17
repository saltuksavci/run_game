using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klon_oluştur : MonoBehaviour
{
    public GameObject altin;
    public GameObject jeep;
    public GameObject tas;
    public GameObject kutuk;
    public GameObject miknatis;

    public Transform oyuncu;

    float silinme_zamani = 5.0f;

    float sag_x_kordinat= 2f;
    float sol_x_kordinat = 1f;


    void Start()
    {
        InvokeRepeating("nesne_klonla", 0, 0.5f);
    }    

   void nesne_klonla() 
    {
        int rastsayi = Random.Range(0, 100);

        if (rastsayi> 0 && rastsayi <80)
        {
            klonla(altin,0.5f);

        }

        if (rastsayi > 80 && rastsayi < 85)
        {
            klonla(kutuk, 0f);

        }

        if (rastsayi > 85 && rastsayi < 90)
        {
            klonla(tas, 0f);

        }
        if (rastsayi > 90 && rastsayi < 95)
        {
            klonla(jeep, 0.5f);

        }
        if (rastsayi > 95 && rastsayi < 100)
        {
            if (oyuncu.gameObject.GetComponent<oyuncu>().miknatis_alindi==false)
            {
                klonla(miknatis, 0.5f);

            }
        }
       
    }


    void klonla(GameObject nesne, float Y_kordinat)
    {
        GameObject yeni_klon = Instantiate(nesne);

        int rastsayi = Random.Range(0, 100);

        if (rastsayi<50)
        {
            yeni_klon.transform.position = new Vector3(sag_x_kordinat, Y_kordinat, oyuncu.position.z + 20.0f);
        }
        else if(rastsayi>50)        
        {
            yeni_klon.transform.position = new Vector3(sol_x_kordinat, Y_kordinat, oyuncu.position.z + 20.0f);
        }
        Destroy(yeni_klon, silinme_zamani);
    }
    void Update()
    {
        
    }
}
