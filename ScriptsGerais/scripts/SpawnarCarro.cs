using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarCarro : MonoBehaviour
{
    Cenario Cen = new();
    public GameObject[] carro;
    public GameObject[] iconCar;

    public GameObject CarroJogador;

 
     public int ContCar;
    // Start is called before the first frame update
    void Start()
    {
        int numC = PlayerPrefs.GetInt("ContCar");
        ContCar = numC;

        Cen.carros =  carro;
        Cen.iconCarros = iconCar;
    }

    // Update is called once per frame
    void Update()
    {
        Cen.GerarCarro(ContCar);

        
        
    }
}
