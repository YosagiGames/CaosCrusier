using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;
using System;
using TMPro;
using System.Security.Authentication.ExtendedProtection;

public class TelaLoading : MonoBehaviour
{
   

    public RectTransform RodaLoad;
    public TMPro.TMP_Text Porcentagem;
    public GameObject CanvasOff;
    public GameObject loadingOn;

    private bool loading;

    public AsyncOperation cena; 

  

    void Start()
    {
        loading = false;
        loadingOn = GameObject.Find("TelaLoading");
        loadingOn.SetActive(false);
        
    }
    void Update()
    { 
            RodaLoad.localEulerAngles += new Vector3(0, 0, 75 * Time.deltaTime);
       
        
    }


    private void LoadingCenas()
    {
        loading = true;


        if (loading)
        {


            loadingOn.SetActive(true);
            CanvasOff.SetActive(false);
          
            loading = false;
        }
        else if (!loading)
        {

            loadingOn.SetActive(false);
            CanvasOff.SetActive(true);
        }





        Debug.Log("CARREGOU");
        ;
    }

    private Quaternion Vector2(int v1, int v2, float progress)
    {
        throw new NotImplementedException();
    }
    public void ChamaLoad()
    {
        LoadingCenas();
    }
}
