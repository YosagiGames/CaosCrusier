using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrocarIMG : MonoBehaviour
{
    public GameObject Australia;
    public GameObject UK;
    public GameObject Japao;
    public GameObject Brasil;
    public GameObject Egito;

    public int num;

    void Start()
    {
        num = 0;
    }
    public void volt()
    {
        if (num > 0)
        {

            num--;
            Debug.Log("abaixou");
        }
       
    }
    public void passar()
    {
        if (num < 4)
        {

            num++;
            Debug.Log("aumenta");
        }
        
    }

    public void mudar()
    {

        Debug.Log("CHamou");
        if(num == 0)
        {
            UK.SetActive(true);

        }
        else
        {
            UK.SetActive(false);
            
        }

        if (num == 1)
        {
            Australia.SetActive(true);

        }
        else
        {
            Australia.SetActive(false);

        }

        if (num == 2)
        {
            Egito.SetActive(true);

        }

        else
        {
            Egito.SetActive(false);

        }

        if (num == 3)
        {
            Japao.SetActive(true);

        }
        else
        {
            Japao.SetActive(false);

        }

        if (num == 4)
        {
            Brasil.SetActive(true);

        }
        else
        {
            Brasil.SetActive(false);

        }

    }
    public void selecionar()
    {
        if (num == 0) {

            SceneManager.LoadScene("ReinoUnido");
            Time.timeScale = 1;
        }

        if (num == 1)
        {

            SceneManager.LoadScene("Australia");
            Time.timeScale = 1;
        }
        if (num == 2)
        {

            SceneManager.LoadScene("Egito");
            Time.timeScale = 1;
        }
        
        if (num == 3)
        {

            SceneManager.LoadScene("Japao");
            Time.timeScale = 1;
        } 
        
        if (num == 4)
        {

            SceneManager.LoadScene("Brasil");
            Time.timeScale = 1;
        } 
    }
}
