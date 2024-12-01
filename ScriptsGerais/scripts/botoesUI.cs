using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class BotoesIU : MonoBehaviour
{
    TelaLoading Load;
    GameObject tela;
    

    public GameObject confi; 
    public GameObject pause;
    public GameObject credito;
    public GameObject TelaTutorial;
    private bool TutoTela;
    public bool confiTela;
    public bool crediTela;
   

    public int contC;

    private void Start()
    {
        Load = GetComponent<TelaLoading>();
        
        confiTela = true;
        crediTela = true;
       
        
    }
    void Update()
    {
       
        Pause();
        Tutorial();
    }
    public void jogar()
    {

        Load.ChamaLoad();
        Load.cena = SceneManager.LoadSceneAsync("SelePerso" );
    }

    public void sair()
    {
        
        Application.Quit();
    }

    public void config()
    {
        if (confiTela)
        {
            confiTela = false;
            confi.SetActive(true);
        }else if (!confiTela) { 
        
        confi.SetActive(false);
            confiTela = true;
        }
                
            
        
        
    }

    public void fechar()
    {
        
        pause.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
    
    public void Pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                AudioListener.pause = true;
                pause.SetActive(true);
                Time.timeScale = 0;
                
            }
        }
    }
    public void creditos()
    {

        if (crediTela)
        {
            crediTela = false;
            credito.SetActive(true);
        }
        else if (!crediTela)
        {

            credito.SetActive(false);
            crediTela = true;
        }
    }
    public void menu()
    {
       
        Load.ChamaLoad();
        Load.cena =  SceneManager.LoadSceneAsync("Menu");
        int numC = PlayerPrefs.GetInt("ContC");
        contC = 0;
        AudioListener.pause = false;    
        Time.timeScale = 1;
    }
   public void Tutorial()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (!TutoTela)
            {
                TelaTutorial.SetActive(true);
                TutoTela = true;

            }
            else if (TutoTela)
            {

                TelaTutorial.SetActive(false);
                TutoTela = false;
            }

        }
      
    }
}
