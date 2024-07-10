using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("------ARABA AYARLARI")]
    public GameObject[] Arabalar;
    public int KacArabaOlsun;
    int KalanAracSayisiDegeri;
    public GameObject DurusNoktasý;
    int AktifAracIndex = 0;
 
    [Header("------CANVAS AYARLARI")]
    public Sprite AracGeldiGorseli;
    public TextMeshProUGUI KalanAracSayisi;
    public GameObject[] ArabaCanvasGorselleri;


    [Header("------PLATFORM AYARLARI")]
    public GameObject Platform_1;
    public GameObject Platform_2;

    [Header("------LEVEL AYARLARI")]
    public int ElmasSayisi;

    public float[] DonusHizlari;
    void Start()
    {
      /*  KalanAracSayisiDegeri = KacArabaOlsun;
        KalanAracSayisi.text = KalanAracSayisiDegeri.ToString();
         for (int i = 0; i < KacArabaOlsun; i++)
         {
            ArabaCanvasGorselleri[i].SetActive(true);
         }
       */
    }

    public void YeniArabaGetir()
    {
        DurusNoktasý.SetActive(true);
        if (AktifAracIndex < KacArabaOlsun)
        {
           
            Arabalar[AktifAracIndex].SetActive(true);
        }
       /* ArabaCanvasGorselleri[AktifAracIndex -1].GetComponent<Image>().sprite = AracGeldiGorseli;
        KalanAracSayisiDegeri--;
        KalanAracSayisi.text = KalanAracSayisiDegeri.ToString(); */
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Arabalar[AktifAracIndex].GetComponent<Araba>().ilerle = true;
            AktifAracIndex++;
        }

        Platform_1.transform.Rotate(new Vector3(0, 0, DonusHizlari[0]), Space.Self);
    }
}
