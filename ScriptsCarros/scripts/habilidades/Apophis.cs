using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Apophis : MonoBehaviour
{
    public GameObject eu;
    public GameObject rampa;
    Rigidbody rb;
    Collision colisorFrente;
    float cooldown = 8f;
    void Start(){
        rb = eu.GetComponent<Rigidbody>();
    }
    void FixedUpdate() 
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0){
            cooldown = 0;
        }
        
    }
    void Update()
    {
        Debug.Log(cooldown);
    }
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.contacts[0].thisCollider.name == rampa.name && collision.gameObject.CompareTag("Carro") && cooldown <= 0f)
        {
            Debug.Log("Contato");
            Rigidbody rbAlvo = collision.gameObject.GetComponent<Rigidbody>();
            rbAlvo.mass = 600f;
            rbAlvo.AddForce((-transform.forward * (rb.mass * Mathf.Pow(rb.velocity.magnitude * 3.6f, 2) / 2) + (rbAlvo.mass / 2f * transform.up)));
            rb.AddForce((transform.forward * rbAlvo.mass) + (-transform.up * rbAlvo.mass));
            cooldown = 8f;
            collision.gameObject.GetComponent<CarroIA>().passado = true;
        }
    }
}
