using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CamFimCorrida: MonoBehaviour
{
    int CamNum;
     public GameObject[] carros;

    public GameObject CamCarroAtivo;

    SpawnarCarro Spa;

    private void Start()
    {
        Spa = GetComponent<SpawnarCarro>();

    }
    public void AtivarCamFim()
    {
        for (int i = 0; i < carros.Length; i++)
        {
            if (i == Spa.ContCar)
            {
                CamCarroAtivo = carros[i];
                CamCarroAtivo.SetActive(true);
            }else 
            {
                CamCarroAtivo = carros[i];
                CamCarroAtivo.SetActive(false);
            }

        }
    }
}
