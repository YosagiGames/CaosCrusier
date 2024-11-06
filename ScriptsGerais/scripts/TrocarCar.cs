using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCar : MonoBehaviour
{

    public GameObject[] Carros;
  

    public GameObject[] Atributos;
  


    public int numC;
    void Start()
    {
        numC = 0;
        

    }

    // Update is called once per frame

    public void volta()
    {


       if(numC > 0)
        {

            numC--;
            Debug.Log("volta");
        }
    } 
    public void pass()
    {

       if(numC < 5) { 
        
        numC++;
            Debug.Log("pass");
        }
    }

    public void troc()
    {
        

        if (numC == 0)
        {

            Carros[0].SetActive(true);
            Atributos[0].SetActive(true);
        }
        else if (numC != 0)
        {
            Carros[0].SetActive(false);
            Atributos[0].SetActive(false);
        }

        if (numC == 1)
        {

            Carros[1].SetActive(true);
            Atributos[1].SetActive(true);
        }
        else if(numC != 1) 
        {
            Carros[1].SetActive(false);
            Atributos[1].SetActive(false);
        }

        if (numC == 2)
        {

            Carros[2].SetActive(true);
            Atributos[2].SetActive(true);
        }
        else if(numC != 2) 
        {
            Carros[2].SetActive(false);
            Atributos[2].SetActive(false);
        }


        if (numC == 3)
        {

            Carros[3].SetActive(true);
            Atributos[3].SetActive(true);
        }
        else if(numC != 3)
        {
            Carros[3].SetActive(false);
            Atributos[3].SetActive(false);
        }

        if (numC == 4)
        {

            Carros[4].SetActive(true);
            Atributos[4].SetActive(true);
        }
        else if(numC != 4)
        {
            Carros[4].SetActive(false);
            Atributos[4].SetActive(false);
        }


        if (numC == 5)
        {

            Carros[5].SetActive(true);
            Atributos[5].SetActive(true);
        }
        else if(numC != 5)
        {
            Carros[5].SetActive(false);
            Atributos[5].SetActive(false);
        }

        PlayerPrefs.SetInt("ContCar", numC);

    }
    public void selec()
    {
        PlayerPrefs.SetInt("ContCar", numC);
        SceneManager.LoadScene("SeleFase");
    }
}
