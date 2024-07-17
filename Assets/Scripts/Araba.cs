using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Araba : MonoBehaviour
{
    public bool ilerle;
    bool DurusNoktas�Durumu = false;

    public GameObject[] Tekerizleri;
    public Transform parent;
    public GameManager _GameManager;
    public GameObject ParcPoint;
    void Start()
    {
        
    }

    void Update()
    {
        if (!DurusNoktas�Durumu)
        {
            transform.Translate(6f * Time.deltaTime * transform.forward);
        }
        if (ilerle)
        {
            transform.Translate(15f * Time.deltaTime * transform.forward);
        }
    }
      private void OnCollisionEnter(Collision collision)
      {
        
       if (collision.gameObject.CompareTag("Parking"))
        {
            ArabaTeknik�slemi();
            transform.SetParent(parent);
            _GameManager.YeniArabaGetir();
        }
        
        else if (collision.gameObject.CompareTag("Araba"))
        {
            _GameManager.CarpmaEfekti.transform.position = ParcPoint.transform.position;
            _GameManager.CarpmaEfekti.Play();
            ArabaTeknik�slemi();

            Destroy(gameObject);// obje havuzunda arabay� false yapaca��m
            _GameManager.Kaybettin();
        }
        
    }
    void ArabaTeknik�slemi()
    {
        ilerle = false;
        Tekerizleri[0].SetActive(false);
        Tekerizleri[1].SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DurusNoktas�"))
        {
            DurusNoktas�Durumu = true;
        }
        else if (other.CompareTag("Elmas"))
        {
            other.gameObject.SetActive(false);
            _GameManager.ElmasSayisi++;
        }
        else if (other.CompareTag("OrtaGobek"))
        {
            _GameManager.CarpmaEfekti.transform.position = ParcPoint.transform.position;
            _GameManager.CarpmaEfekti.Play();
            ArabaTeknik�slemi();

            _GameManager.Kaybettin();
        }
        else if (other.CompareTag("On_Parking"))
        {
          //  other.gameObject.GetComponent<On_Parking>().ParkingAktiflestir();
            other.gameObject.GetComponent<On_Parking>().parking.SetActive(true);
        }
    }

}
