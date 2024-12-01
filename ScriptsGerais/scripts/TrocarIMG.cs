using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrocarIMG : MonoBehaviour
{
    Cenario Cen = new();

    public GameObject[] fases;

    public GameObject faseAtual;

    public int num;

    TelaLoading Load;

    void Start()
    {
        Load = GetComponent<TelaLoading>();

        num = 0;

        Cen.cena = fases;
      
    }
    public void volt()
    {
        if (num > -1)
        {

            num--;
            Debug.Log("abaixou");
        }
        if (num == -1)
        {
            num = 4;
        }
    }
    public void passar()
    {
        if (num < 5)
        {

            num++;
            Debug.Log("aumenta");
        }
        if (num == 5)
        {
            num = 0;
        }

    }
    
    public void mudar()
    {
      
        Cen.GerarCenario(num);

       
    }
    public void selecionar()
    {
        if (num == 0) {
            Load.ChamaLoad();
            Load.cena = SceneManager.LoadSceneAsync("ReinoUnido");
            Time.timeScale = 1;
        }

        if (num == 1)
        {
            Load.ChamaLoad();
            Load.cena = SceneManager.LoadSceneAsync("Australia");
            Time.timeScale = 1;
        }
        if (num == 2)
        {
            Load.ChamaLoad();
            Load.cena = SceneManager.LoadSceneAsync("Egito");
            Time.timeScale = 1;
        }
        
        if (num == 3)
        {
            Load.ChamaLoad();
            Load.cena = SceneManager.LoadSceneAsync("Japao");
            Time.timeScale = 1;
        } 
        
        if (num == 4)
        {
            Load.ChamaLoad();
            Load.cena = SceneManager.LoadSceneAsync("Brasil");
            Time.timeScale = 1;
        } 
    }
}
