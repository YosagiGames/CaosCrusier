using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Reflection;

public class FinalizarCorrida : MonoBehaviour
{
   
    Corrida Cor = new();
    CamFimCorrida CamFim;
    SpawnarCarro Spa;
  

    public TMPro.TMP_Text posicao;
    public TMPro.TMP_Text pontos;
    public TMPro.TMP_Text ultrapassagens;
    public TMPro.TMP_Text tempoFinal;
    public TMPro.TMP_Text tempoAt;
    public TMPro.TMP_Text _conta;

    public GameObject fimTimeLine;
   
    public bool Terminar;

    float transicao;
    public float ResulFinal;
    public int ult;
    public int ultMi;
    public int ultMa;


    public GameObject[] Carros;
    public GameObject   Carro;
    public GameObject TelResultados;
    public GameObject hud;
    void Start()
    {
        _conta = GameObject.Find("Ultrapassagens").GetComponent<TMP_Text>();
        tempoAt = GameObject.Find("Tempo").GetComponent<TMP_Text>();
        tempoFinal = GameObject.Find("tempoRest").GetComponent<TMP_Text>();
        pontos = GameObject.Find("pontuacao").GetComponent<TMP_Text>();
        hud = GameObject.Find("EleHUD");

        
        TelResultados = GameObject.Find("Resultados");
        TelResultados.SetActive(false);

        Terminar = false;

        Spa = GetComponent<SpawnarCarro>();
        CamFim = GetComponent<CamFimCorrida>();

        Cor.Tempo = 721f;
        Cor.UltrapassagensMax = ultMa;
        Cor.UltrapassagensMin = ultMi;
        Cor.ComecarCorrida();
        InvokeRepeating("IniciaContagem", 1f, 1f);

        fimTimeLine.SetActive(false);

        transicao = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< Carros.Length; i++)
        {
            if (i == Spa.ContCar)
            {
                Carro = Carros[i];
            }

        }
        Debug.Log(Cor.VerResultados(ult));

      

        if (_conta != null)
        {
            _conta.text = ult.ToString() + " / " + ultMi.ToString();

        }
        ult = Carro.GetComponent<CarroJogador>().ultrapassagens;
       
        Terminar = Cor.TerminarCorrida(ult);
        AcabarCorrida();

        ResulFinal = Cor.Resultados;
    }

    private void AcabarCorrida()
    {
        
       
        if (Terminar == true)
        {
            fimTimeLine.SetActive(true);
            CamFim.AtivarCamFim();
            transicao += Time.deltaTime;

           hud.SetActive(false);
            

            if (transicao >= 5f)
            {
                Time.timeScale = 0;
                AudioListener.pause = true;
                TelResultados.SetActive(true);

                pontos.text = Cor.VerResultados(ult).ToString();
                ultrapassagens.text = ult.ToString() + " / " + ultMi.ToString();




                if (Cor.Ganhou == true)
                {
                    posicao.text = "Vitoria";

                }
                else if (Cor.Ganhou == false)
                {
                    posicao.text = "DERROTADO";
                }
            }

        }
    }
    public void IniciaContagem()
    {

        Cor.ContarTempo();

        Contador(Cor.TempoAtual, GetTempo(), GetTempoFinal());
    }
    public TMPro.TMP_Text GetTempo()
    {
        return tempoAt;
    }
    
    public TMPro.TMP_Text GetTempoFinal()
    {
        return tempoFinal;
    }

    private void Contador(float ContaTempo, TMPro.TMP_Text tempo, TMPro.TMP_Text tempoFinal)
    {

        if (ContaTempo < 0f)
        {
            ContaTempo = 0f;
        }


        float minutos = Mathf.FloorToInt(ContaTempo / 60);
        float segundos = Mathf.FloorToInt(ContaTempo % 60);
        tempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        tempoFinal.text = string.Format("{0:00}:{1:00}", minutos, segundos);

    }

}

