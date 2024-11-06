using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotõesIU : MonoBehaviour
{

    public GameObject confi; 
    public GameObject pause;
    public GameObject credito;

    public int contC;

    void Update()
    {
        Pause();
    }
    public void jogar()
    {
        SceneManager.LoadScene("SelePerso");
    }

    public void sair()
    {
        Application.Quit();
    }

    public void config()
    {

    confi.SetActive(true);
    }

    public void fechar()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                pause.SetActive(true);
                Time.timeScale = 0;
                
            }
        }
    }
    public void creditos()
    {
        credito.SetActive(true);
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
        int numC = PlayerPrefs.GetInt("ContC");
        contC = 0;
    }
   
}
