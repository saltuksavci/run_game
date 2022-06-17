using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncu : MonoBehaviour

{
    

    public Animator animasyon;
    public GameObject toz_efekti;
    public GameObject altin_efekti;

    public GameObject bitti_pnl;

    public TMPro.TextMeshProUGUI puan_txt;
    public TMPro.TextMeshProUGUI toplanan_altın_txt;

    public Transform yol1;
    public Transform yol2;

    public Rigidbody rigi;

    bool sag = true;

    int puan = 0;
    int toplanan_altin = 0;

    public bool miknatis_alindi = false;

    public AudioSource ses_dosyasi;
    public AudioSource kosma_ses_dosyasi;
    public AudioClip altin_temas_sesi;
    public float hiz=5;
    public bool havada;

    



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SON_1")
        {
            yol2.position = new Vector3(yol1.position.x, yol1.position.y, yol1.position.z + 45f);
        }
        if (other.gameObject.name == "SON_2")
        {
            yol1.position = new Vector3(yol2.position.x, yol2.position.y, yol2.position.z + 45f);
        }

        if (other.gameObject.tag=="engel")
        {
            bitti_pnl.SetActive(true);
            
            Time.timeScale = 0.0f;

           

        }


        if (other.gameObject.tag=="altin")
        {
            ses_dosyasi.PlayOneShot(altin_temas_sesi);
            GameObject yeni_altin_efekti = Instantiate(altin_efekti, other.gameObject.transform.position, Quaternion.identity);
            Destroy(yeni_altin_efekti, 0.5f);

            Destroy(other.gameObject);

            toplanan_altin++;
            puan += 5;

            puan_txt.text = puan.ToString("00000");
            toplanan_altın_txt.text = toplanan_altin.ToString();

        }

        if (other.gameObject.tag=="miknatis")
        {
            GameObject[] tum_miknatislar = GameObject.FindGameObjectsWithTag("miknatis");
            foreach(GameObject miknatis in tum_miknatislar)
            {
                Destroy(miknatis);

                miknatis_alindi = true;
                Invoke("miknatisi_resetle", 10.0f);

            }

           
            miknatis_alindi = true;
            Invoke("miknatisi_resetle", 10.0f);
        }        

    }
    
    void miknatisi_resetle()
    {

        miknatis_alindi = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        //havdakotrol
        havada = false;

        toz_efekti.SetActive(true);
        kosma_ses_dosyasi.enabled = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        //havdakotrol
        havada = true;
        toz_efekti.SetActive(false);
        kosma_ses_dosyasi.enabled = false;

    }
    






    void Update()
    {
       

    }
    private void FixedUpdate()
    {

        hareket();
        
        hiz += Time.deltaTime * 2f;
    }


    void hareket()

    {
        if (Input.GetKeyDown(KeyCode.UpArrow)&!havada)
        {
            animasyon.SetBool("zipla", true);
            rigi.velocity = Vector3.up * 300.0f * Time.deltaTime;
            Invoke("ziplama_iptal", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            sag = true;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sag = false;

        }
        if (sag)
        {

            transform.position = Vector3.Lerp(transform.position, new Vector3(2.4f, transform.position.y, transform.position.z), Time.deltaTime * 3f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.4f, transform.position.y, transform.position.z), Time.deltaTime * 3f);
        }
        transform.Translate(0, 0, hiz * Time.deltaTime);

    }
    

    void ziplama_iptal()
    {
        animasyon.SetBool("zipla", false);
    }
}
