using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("------ARABA AYARLARI")]
    public GameObject[] Arabalar;
    public int KacArabaOlsun;
    int KalanAracSayisiDegeri;
    public GameObject DurusNoktas�;
    int AktifAracIndex = 0;
 
    [Header("------CANVAS AYARLARI")]
    public Sprite AracGeldiGorseli;
    public TextMeshProUGUI KalanAracSayisi;
    public GameObject[] ArabaCanvasGorselleri;
    public TextMeshProUGUI[] Textler;
    public GameObject[] Panellerim;
    public GameObject[] TapToButonlar;


    [Header("------PLATFORM AYARLARI")]
    public GameObject Platform_1;
    public GameObject Platform_2;

    [Header("------LEVEL AYARLARI")]
    public int ElmasSayisi;

    public float[] DonusHizlari;
    void Start()
    {
        VarsayilanDegerleriKontrolEt();
       KalanAracSayisiDegeri = KacArabaOlsun;
       /* KalanAracSayisi.text = KalanAracSayisiDegeri.ToString();
         for (int i = 0; i < KacArabaOlsun; i++)
         {
            ArabaCanvasGorselleri[i].SetActive(true);
         }
       */
    }

    public void YeniArabaGetir()
    {
        DurusNoktas�.SetActive(true);
        KalanAracSayisiDegeri--;
        if (AktifAracIndex < KacArabaOlsun)
        {
           
            Arabalar[AktifAracIndex].SetActive(true);
        }
        else
        {
            Kazand�n();

        }
        
        /* ArabaCanvasGorselleri[AktifAracIndex -1].GetComponent<Image>().sprite = AracGeldiGorseli;

         KalanAracSayisi.text = KalanAracSayisiDegeri.ToString(); */
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Arabalar[AktifAracIndex].GetComponent<Araba>().ilerle = true;
            AktifAracIndex++;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Panellerim[0].SetActive(false);
        }

        Platform_1.transform.Rotate(new Vector3(0, 0, DonusHizlari[0]), Space.Self);
    }

    public void Kaybettin()
    {
        PlayerPrefs.SetInt("Elmas", PlayerPrefs.GetInt("Elmas") + ElmasSayisi);//KAybedince bile elmas kazan�r!!

        Textler[6].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[7].text = SceneManager.GetActiveScene().name;
        Textler[8].text = (KacArabaOlsun - KalanAracSayisiDegeri).ToString();
        Textler[9].text = ElmasSayisi.ToString();

       
        Panellerim[1].SetActive(true);
        Invoke("KaybettinButonuOrtayaCikart", 2f);
    }
    void KaybettinButonuOrtayaCikart()
    {
        TapToButonlar[0].SetActive(true);

    }
    void Kazand�nButonuOrtayaCikart()
    {
        TapToButonlar[1].SetActive(true);
    }

    void Kazand�n()
    {
        PlayerPrefs.SetInt("Elmas", PlayerPrefs.GetInt("Elmas") + ElmasSayisi);//KAybedince bile elmas kazan�r!!

        Textler[2].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[3].text = SceneManager.GetActiveScene().name;
        Textler[4].text = (KacArabaOlsun - KalanAracSayisiDegeri).ToString();
        Textler[5].text = ElmasSayisi.ToString();

        Panellerim[2].SetActive(true);
        Invoke("Kazand�nButonuOrtayaCikart", 2f);
    }


    // BELLEK Y�TEN�M�

    void VarsayilanDegerleriKontrolEt()
    {
        if (!PlayerPrefs.HasKey("Elmas"))
        {
            PlayerPrefs.SetInt("Elmas", 0);
            PlayerPrefs.SetInt("Level", 1);
        }

        Textler[0].text = PlayerPrefs.GetInt("Elmas").ToString();
        Textler[1].text = SceneManager.GetActiveScene().name;

    }
    public  void izleVeDevamEt() 
    {
        // reklam i�leri
    }
    public void izleVeDahaFazlaKazan()
    {
        // reklam i�leri 
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void SonrakiLevel()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex +1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
