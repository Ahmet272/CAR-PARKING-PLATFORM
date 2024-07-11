using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Araba : MonoBehaviour
{
    public bool ilerle;
    bool DurusNoktasıDurumu = false;

    public GameObject[] Tekerizleri;
    public Transform parent;
    public GameManager _GameManager;
    void Start()
    {
        
    }

    void Update()
    {
        if (!DurusNoktasıDurumu)
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
        if (collision.gameObject.CompareTag("DurusNoktası"))
        {
            DurusNoktasıDurumu = true;
            _GameManager.DurusNoktası.SetActive(false);
        }
       else if (collision.gameObject.CompareTag("Parking"))
        {
            ilerle = false;
            Tekerizleri[0].SetActive(false);
            Tekerizleri[1].SetActive(false);
            transform.SetParent(parent);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            _GameManager.YeniArabaGetir();
        }
        else if (collision.gameObject.CompareTag("OrtaGobek"))
        {
            Destroy(gameObject);// Canvas çıkacak // obje havuzunda arabayı false yapacağım
            _GameManager.Kaybettin();
        }
        else if (collision.gameObject.CompareTag("Araba"))
        {
            Destroy(gameObject);// obje havuzunda arabayı false yapacağım
            _GameManager.Kaybettin();
        }
        else if (collision.gameObject.CompareTag("Elmas"))
        {
            collision.gameObject.SetActive(false);
            _GameManager.ElmasSayisi++;
        }
    }
}
