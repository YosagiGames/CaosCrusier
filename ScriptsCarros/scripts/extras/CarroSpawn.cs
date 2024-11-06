using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class CarroSpawn : MonoBehaviour
{
    [Tooltip("Pontos do mapa onde os carros serão invocados")]
    public Transform[] SpawnPoints;

    [Tooltip("GameObjects dos carros")]
    public GameObject[] Carros;

    [Tooltip("GameObject que vai guardar os carros instanciados")]
    public GameObject IAParent;

    [Tooltip("Qual o Waypoint atual para os carros seguirem")]
    public int atual;

    GameObject rotaAtual;
    private float Cooldown;

    private GameObject newCarro;
    private string[] rota = {"a", "b", "c", "d", "e", "f"};

    

    private void FixedUpdate()
    {
         if(Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Transform parent = collision.gameObject.transform.parent.parent;
        Debug.Log(collision.gameObject.name + +Cooldown);
       
        if (parent.parent.name == "player" && Cooldown <= 0)
        {
            
            for (int i = 0; i < SpawnPoints.Length && IAParent.transform.childCount < 6; i++)
            {
                Cooldown = 12f;
               
                
                rotaAtual = GameObject.Find($"Caminho-{rota[i]}");
                newCarro = Instantiate(Carros[i], SpawnPoints[i].transform.position,SpawnPoints[i].localRotation, IAParent.transform);
                newCarro.GetComponentInChildren<CarroIA>().atual = atual;
                newCarro.GetComponentInChildren<CarroIA>().rota = rota[i];
            }
        }
    }
}   
