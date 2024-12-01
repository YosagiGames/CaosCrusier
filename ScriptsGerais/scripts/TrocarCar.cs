using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrocarCar : MonoBehaviour
{
    Cenario Cen = new();

    public GameObject[] Carros;

    Slider velocidade;
    Slider controle;

    public GameObject[] Atributos;


    TelaLoading Load;

    public int numC;
    void Start()
    {
        numC = 0;
        Load = GetComponent<TelaLoading>();

        velocidade = GameObject.Find("velocidade").GetComponent<Slider>();
        controle = GameObject.Find("controle").GetComponent<Slider>();

        velocidade.maxValue = 5;
        controle.maxValue = 5;

        
       Cen.iconCarros = Atributos;
        Cen.carros = Carros;

    }

    private void Update()
    {
        velocidade.value = numC + 1;
        controle.value = 5 - numC;
    }

  

    public void volta()
    {


       if(numC > -1)
        {

            numC--;
            Debug.Log("volta");
        }
        
        if (numC < 0)
        {
            numC = 5;
        }
    } 
    public void pass()
    {

       if(numC < 6) { 
        
        numC++;
            Debug.Log("pass");
        }
        if (numC == 6)
        {
            numC = 0;
        }


    }

    public void troc()
    {


        Cen.GerarCarro(numC);
            
        }
    public void selec()
    {
        PlayerPrefs.SetInt("ContCar", numC);
        Load.ChamaLoad();
        Load.cena = SceneManager.LoadSceneAsync("SeleFase");
    }
}
