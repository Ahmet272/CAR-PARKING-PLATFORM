using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Parking : MonoBehaviour
{
    public GameObject parking;
    

    public void ParkingAktiflestir()
    {
        parking.SetActive(true);
    }
}
