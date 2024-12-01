using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario
{

    

    public GameObject[] carros { get; set; }
    public GameObject[] iconCarros { get; set; }
    public GameObject[] cena { get; set; }



    public void GerarCarro(int numCarros)
    {
        for (int i = 0; i < carros.Length; i++)
        {
            if (i == numCarros)
            {
                carros[i].SetActive(true);
                iconCarros[i].SetActive(true);
            }
            else
            {
                carros[i].SetActive(false);
                iconCarros[i].SetActive(false);
            }
        }

    }
    public void GerarCenario(int numCena)
    {

        for (int i = 0; i < cena.Length; i++)
        {
            if (i == numCena)
            {

                cena[i].SetActive(true);

            }
            else
            {
                cena[i].SetActive(false);

            }
        }
    }

}
