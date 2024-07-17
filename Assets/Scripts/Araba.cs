using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Araba : MonoBehaviour
{
    public bool ilerle;
    bool DurusNoktasýDurumu = false;

    public GameObject[] Tekerizleri;
    public Transform parent;
    public GameManager _GameManager;
    public GameObject ParcPoint;
    void Start()
    {
        
    }

    void Update()
    {
        if (!DurusNoktasýDurumu)
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
            ArabaTeknikÝslemi();
            transform.SetParent(parent);
            _GameManager.YeniArabaGetir();
        }
        
        else if (collision.gameObject.CompareTag("Araba"))
        {
            _GameManager.CarpmaEfekti.transform.position = ParcPoint.transform.position;
            _GameManager.CarpmaEfekti.Play();
            ArabaTeknikÝslemi();

            Destroy(gameObject);// obje havuzunda arabayý false yapacaðým
            _GameManager.Kaybettin();
        }
        
    }
    void ArabaTeknikÝslemi()
    {
      //  ilerle = false;
        Tekerizleri[0].SetActive(false);
        Tekerizleri[1].SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DurusNoktasý"))
        {
            DurusNoktasýDurumu = true;
        }
        else if (other.CompareTag("Elmas"))
        {
            other.gameObject.SetActive(false);
            _GameManager.ElmasSayisi++;
            _GameManager.Sesler[0].Play();
        }
        else if (other.CompareTag("OrtaGobek"))
        {
            _GameManager.CarpmaEfekti.transform.position = ParcPoint.transform.position;
            _GameManager.CarpmaEfekti.Play();
            ArabaTeknikÝslemi();

            _GameManager.Kaybettin();
        }
        else if (other.CompareTag("On_Parking"))
        {
           other.gameObject.GetComponent<On_Parking>().ParkingAktiflestir();
           // other.gameObject.GetComponent<On_Parking>().parking.SetActive(true);
        }
    }

}
