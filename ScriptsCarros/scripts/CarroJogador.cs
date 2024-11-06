using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class CarroJogador : MonoBehaviour
{
    CarroBehavior car = new CarroBehavior();

    public float Rpm;
    public int Marcha;
    public GameObject carro;
    public AnimationCurve curva;
    public WheelCollider[] rodas;
    public float[] marchas;

    public float lvlVel;
    private float acc;
    public float sent;

    bool contestadoE;
    bool contestadoD;
    public int ultrapassagens;

    public TMP_Text _vel;
    public TMP_Text _ult;

    int pontuacao;

    Rigidbody rb;


    public Transform centro;
    void Start()
    {
        rb = carro.GetComponent<Rigidbody>();
        rb.centerOfMass = centro.localPosition; 
        acc = 0;
        sent = 0;
        car.DefirValores(lvlVel, rodas, curva, marchas, rb);
        for (int i = 0; i < rodas.Length; i++)
        {
            rodas[i].ConfigureVehicleSubsteps(5, 12, 15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Marcha = car.marchaAtual;
        
        sent = Input.GetAxis("Horizontal");
        acc = Input.GetAxis("Vertical");
    }
    void FixedUpdate() 
    {
        car.DefinirDirecao(acc, sent);
        car.Andar(transform.up, lvlVel, rodas[0].transform.forward);
        Rpm = car.rpm;
        
    }
    private void LateUpdate()
    {
        lancar(rodas[0].transform.position, rodas[2].transform.position, rodas[0].transform.right);
        lancar(rodas[1].transform.position, rodas[3].transform.position, -rodas[1].transform.right);
    }

    Ray ray;
    RaycastHit[] idFrente;

    Ray ray2;
    RaycastHit[] hits2;

    Ray ray3;
    RaycastHit[] idTras;


    bool id1;
    bool id2;

    
    GameObject carroOponente;

    public void lancar(Vector3 origin, Vector3 origin2,Vector3 sent)
    {
        ray3 = new Ray(origin, sent);
        ray2 = new Ray((origin + origin2) / 2, sent);
        ray = new Ray(origin2, sent);

        idFrente = Physics.RaycastAll(ray, 45f * sent.magnitude);
        idTras = Physics.RaycastAll(ray3, 45f * sent.magnitude);

        

        for (int i = 0; i < idFrente.Length; i++) {
            if (!idFrente[i].collider.gameObject.transform.parent.CompareTag("Mapa"))
            {
                carroOponente = idFrente[i].collider.gameObject.transform.parent.parent.gameObject;
                if (carroOponente.CompareTag("Carro"))
                {
                    id1 = true;
                    hits2 = Physics.RaycastAll(ray2, 45f * sent.magnitude);
                    
                    if (hits2[i].collider.transform.parent.parent.gameObject.CompareTag("Carro"))
                    {
                        id2 = true;
                        
                    }
                }
            }
        }

        if (!id1)
        {
            for (int i = 0; i < idTras.Length; i++)
            {
                if (!idTras[i].collider.gameObject.transform.parent.CompareTag("Mapa"))
                {
                    carroOponente = idTras[i].collider.gameObject.transform.parent.parent.gameObject;

                    if (carroOponente.CompareTag("Carro"))
                    {
                        hits2 = Physics.RaycastAll(ray2, 45f * sent.magnitude);
                        if (hits2[i].collider.transform.parent.parent.gameObject.CompareTag("Carro"))
                        {
                            id2 = true;
                          

                        }
                    }
                }
            }
        }

        if (id2 && idFrente.Length < hits2.Length) {
            if (id1)
            {
                carroOponente.GetComponent<CarroIA>().passado = true;
                id1 = false;
                id2 = false;
                hits2 = null;
            }
            else
            {
                carroOponente.GetComponent<CarroIA>().passado = false;
                id1 = false;
                id2 = false;
                hits2 = null;
            }
        }
    }
}
