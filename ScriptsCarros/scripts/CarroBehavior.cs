using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;

using UnityEngine;
using UnityEngine.UIElements;
public class CarroBehavior
{
    public WheelCollider[] rodasGuias { get; set; }
    public UnityEngine.Vector3 carForca { get; set; }
    private AnimationCurve curva { get; set; }
    private Rigidbody rb { get; set; }
    public float vel { get; set; }
    private float acc { get; set; }
    private float sent { get; set; }
    public float rpm { get; set; }
    private float rpmMax { get; set; }
    private float rpmMin { get; set; }
    private float freio { get; set; }
    private float torqueMax { get; set; }
    public float[] racioMarchas { get; set; }
    public int marchaAtual { get; set; }
    private bool indoFrente { get; set; }

    public void DefirValores(float lvl, WheelCollider[] rodas, AnimationCurve curve, float[] marchas, Rigidbody rigid)
    {
        torqueMax = 1000f + (lvl * 1500f);
        rpmMax = 2000f + (lvl * 500f);
        rpmMin = 500f + (lvl * 300f);
        freio = (torqueMax * 7f) - (2500f * lvl);
        rodasGuias = rodas;
        curva = curve;
        racioMarchas = marchas;
        rb = rigid;
        marchaAtual = 0;
        indoFrente = true;
    }
    public void DefinirDirecao(float acel, float senti)
    {
        acc = acel;
        sent = senti;
    }
    public void Andar(UnityEngine.Vector3 up, float lvl, UnityEngine.Vector3 forwardR)
    {
        //guia do carro
        for(int i = 0; i < rodasGuias.Length / 2; i++)
        {
            rodasGuias[i].steerAngle = sent * curva.Evaluate(vel) * (1 + (((6f / (lvl + 0.75f)) - 2f) / 6.5f));
        }
        if (sent == 0) {
            for (int i = 0; i < rodasGuias.Length / 2; i++)
            {
                rodasGuias[i].steerAngle = 0;
            }
        }
        


        //vel e rpm
        vel = Mathf.Floor(rb.velocity.magnitude * 3.6f);
        rpm = Mathf.Floor(vel * racioMarchas[marchaAtual] * 5f);


        //troca de marcha
        if (!indoFrente) 
        {
            //marcha ré
            marchaAtual = 4;
            rpmMax = 1000 + (lvl * 50);
            rpmMin = 160 + (lvl * 100);
        }
        else
        {
            rpmMax = 2750f + (lvl * 450f);
            rpmMin = 480f + (lvl * 300f);
        }
        if(rpm > rpmMax && indoFrente)
        {
            marchaAtual++;
            if(marchaAtual == racioMarchas.Length)
            {
                marchaAtual--;
            }
        }
        if(rpm < rpmMin && indoFrente)
        {
            marchaAtual--;
            if(marchaAtual <  0){
                marchaAtual = 0;
            }
        }


        //forcas exercidas ao carro
        if (acc < 0f && vel == 0)
        {
            indoFrente = false;
        }
        else if (acc > 0f && vel == 0)
        {
            indoFrente = true;
        }


        carForca = forwardR * ((torqueMax / (marchaAtual + 1)) + (torqueMax / 1.25f));

        if ((indoFrente && acc < 0) || (!indoFrente && acc > 0)) //freio
        {
            for (int i = 0; i < rodasGuias.Length; i++)
            {
                rodasGuias[i].brakeTorque = freio / 1.5f;
            }
            rb.AddTorque((up * (freio / 5) * vel / 55f) * sent);
            acc = 0;
        }
        else
        {
            for (int i = 0; i < rodasGuias.Length; i++)
            {
                rodasGuias[i].brakeTorque = 0;
            }
        }

        for (int i = 0; i < rodasGuias.Length / 2; i++)
        {  
            if((rpm > rpmMax && marchaAtual == 4) || acc == 0)
            {
                rodasGuias[i].motorTorque = 0;
            }
            else
            {
                rodasGuias[i].motorTorque = Mathf.Floor(carForca.magnitude * acc);
            }
        }
        //Debug.Log($"Força do carro: {Mathf.Floor(carForca.magnitude)}, RPM: {rpm}, Marcha atual: {marchaAtual + 1}, Velocidade: {vel} Km/h, Curva: {rodasGuias[1].steerAngle}, Indo para frente? {indoFrente}");      
    }
    public void OnTriggerEnter(Collider colisor)
    {
        Debug.Log(colisor.name);
        if(colisor.gameObject.CompareTag("Speedbost")){
            Debug.Log("Speedbost");
            rb.AddForce(-colisor.gameObject.transform.forward * 500f);
        }
    }
}
