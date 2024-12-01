using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security;
using UnityEngine;

public class Corrida
{
    public int UltrapassagensMin { get; set; }
    public int UltrapassagensMax { get; set; }
    public float Tempo { get; set; }
    public float TempoAtual {  get; set; }
    public float Resultados { get; set; }
    public bool Ganhou {  get; set; }
    private bool FimCorrida {  get; set; }  

    public void ComecarCorrida()
    {
        TempoAtual = Tempo;
        FimCorrida = false;
    }

    public void ContarTempo()
    {
        if (!FimCorrida && TempoAtual > 0) 
        {
            TempoAtual --;
        }
    }
    public bool TerminarCorrida(int ultrapassagem)
    {
        //Verifica se está qualificado a ganhar a corrida
        if(ultrapassagem >= UltrapassagensMin  && ultrapassagem < UltrapassagensMax)
        {
            Ganhou = true;
        }
        else if (ultrapassagem >= UltrapassagensMax)
        {
            FimCorrida = true;
            Ganhou = true;
        }
        else
        {
            Ganhou = false;
        }

        if(TempoAtual <= 0)
        {
            FimCorrida = true;
        }

        return FimCorrida;
    }
    public float VerResultados(int ultrapassagem)
    {
        Resultados = ((Tempo - TempoAtual/2) * ultrapassagem / ((UltrapassagensMax + 1) - ultrapassagem));

        return Resultados;
    }
}
