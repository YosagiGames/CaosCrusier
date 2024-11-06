using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using UnityEngine;

public class CarroIA : MonoBehaviour
{
    CarroBehavior mov = new CarroBehavior();
    CarroJogador jogador;
    
    Rigidbody rb;
    Caminho[] rotas;
    float vel;

    public string rota;
    public int atual;
    public GameObject carro;
    public AnimationCurve curva;
    public WheelCollider[] rodas;
    public int lvl;
    public float[] marchas;

    public Transform centro;
    float acc;
    public float sent;

    public bool passado = false;
    bool darPonto = true;

    
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.Find("player").GetComponentInChildren<CarroJogador>();
        rb = carro.GetComponent<Rigidbody>();
        rb.centerOfMass = centro.localPosition;
        GameObject parentWaypoint = GameObject.Find($"Caminho-{rota}");
        rotas = parentWaypoint.GetComponentsInChildren<Caminho>();
        mov.DefirValores(lvl, rodas,curva, marchas, rb);
        for (int i = 0; i < rodas.Length; i++)
        {
            rodas[i].ConfigureVehicleSubsteps(5, 12, 15);
        }
    }

    void FixedUpdate() {
        vel = rb.velocity.magnitude * 3.6f;

        if (rotas[atual].velRecomendada * 3.6f > vel)
        {
            acc = 1f;
        }
        else
        {
            acc = -1f;
        }

        Vector3 dir = transform.InverseTransformPoint(new Vector3(rotas[atual].transform.position.x, transform.position.y, rotas[atual].transform.position.z));
        sent = Mathf.Clamp((dir.x / dir.magnitude) * 5f, -1, 1);

        if (Vector3.Distance(transform.position, rotas[atual].transform.position) < 10f)
        {
            atual++;
            if(atual == rotas.Length)
            {
                atual = 0;
            }
        }
        mov.DefinirDirecao(acc, sent);
        mov.Andar(transform.up, lvl, rodas[1].transform.forward);




        if (passado == darPonto) {
            if (darPonto) {
                jogador.ultrapassagens++;
            }
            else
            {
                jogador.ultrapassagens--;
            }
            darPonto = !darPonto;
        }

        if (passado)
        {
            if (Vector3.Distance(transform.position, jogador.transform.position) > 20f ) { 
                Destroy(carro);
                Debug.Log("ponto");
            }
        }
    }
}