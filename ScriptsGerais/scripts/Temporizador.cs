using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public float temporizador;

    public TMP_Text tempo;


    void Start()
    {
        tempo = GameObject.Find("Tempo").GetComponent<TMP_Text>();
        InvokeRepeating("IniciaContagem", 1f, 1f);

        temporizador = 720f;
    }

    private void IniciaContagem()
    {
      if (temporizador > 0)
        {
            temporizador--;
        }
        Contador(temporizador, GetTempo());
    }

    private TMPro.TMP_Text GetTempo()
    {
        return tempo;
    }

    private void Contador(float ContaTempo, TMPro.TMP_Text tempo)
    {
     
        if(ContaTempo < 0f)
        {
            ContaTempo = 0f;
        }


        float minutos = Mathf.FloorToInt(ContaTempo / 60);
        float segundos = Mathf.FloorToInt(ContaTempo % 60);
        tempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);

    }
}
