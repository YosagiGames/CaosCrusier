using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContUltra : MonoBehaviour
{
    Corrida cor = new();
    CarroJogador Car;

    public int ultrapassagem;
    public int ultrapassagemMIN;

    
    public TMPro.TMP_Text _conta;

    void Start()
    {
        _conta = GameObject.Find("Ultrapassagens").GetComponent<TMP_Text>();
    }
    
    // Update is called once per frame
    void Update()
    {
            ultrapassagem =GetComponent<CarroJogador>().ultrapassagens;
            cor.UltrapassagensMin = ultrapassagemMIN;
        
        if (_conta != null)
        {
            _conta.text = ultrapassagem.ToString() + " / " + ultrapassagemMIN.ToString();

        }
    }
    
}

