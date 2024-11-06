using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarCarro : MonoBehaviour
{

    public GameObject[] carro;
    public GameObject[] iconCar;

 
     public int ContCar;
    // Start is called before the first frame update
    void Start()
    {
        int numC = PlayerPrefs.GetInt("ContCar");
        ContCar = numC;
    }

    // Update is called once per frame
    void Update()
    {
        if (ContCar == 0)
        {

            carro[0].SetActive(true);
            iconCar[0].SetActive(true);
        }
        else if (ContCar != 0)
        {
            carro[0].SetActive(false);
            iconCar[0].SetActive(false);
        }

        if (ContCar == 1)
        {
            carro[1].SetActive(true);
            iconCar[1].SetActive (true);
        }
        else if (ContCar != 1) {
            carro[1].SetActive(false);
            iconCar[1].SetActive(false);

        }

        if (ContCar == 2)
        {

            carro[2].SetActive(true);
            iconCar[2].SetActive(true);
        }
        else if (ContCar != 2)
        {
            carro[2].SetActive(false);
            iconCar[2].SetActive(false);
        }
        
        if (ContCar == 3)
        {

            carro[3].SetActive(true);
            iconCar[3].SetActive(true);
        }
        else if (ContCar != 3)
        {
            carro[3].SetActive(false);
            iconCar[3].SetActive(false);
        }

        if (ContCar == 4)
        {

            carro[4].SetActive(true);
            iconCar[4].SetActive(true);
        }

        else if (ContCar != 4)
        {
            carro[4].SetActive(false);
            iconCar[4].SetActive(false);
        }

        if (ContCar == 5)
        {

            carro[5].SetActive(true);
            iconCar[5].SetActive(true);

        }
        else if (ContCar != 5)
        {
            carro[5].SetActive(false);
            iconCar[5].SetActive(false);
        }
    }
}
