using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Apophis : MonoBehaviour
{
    public GameObject eu;
    public GameObject rampa;
    Rigidbody rb;
    Collision colisorFrente;

    Slider barra;
    public Animator animator;
    float cooldown = 0f;
    void Start(){
        rb = eu.GetComponent<Rigidbody>();
        barra = GameObject.Find("barra").GetComponent<Slider>();
        barra.maxValue = 8;
    }
    void FixedUpdate() 
    {
        cooldown -= Time.deltaTime;
        barra.value = 8 - cooldown;
        if(cooldown <= 0)
        {
            cooldown = 0;

            animator.SetBool("Desativando", false);
        }
        
    }
    
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.contacts[0].thisCollider.name == rampa.name && collision.gameObject.CompareTag("Carro") && cooldown <= 0f)
        {
            animator.SetBool("Desativando", true);
            Debug.Log("Contato");

            Rigidbody rbAlvo = collision.gameObject.GetComponent<Rigidbody>();
           
            rbAlvo.AddForce((-transform.forward * (2500 * rb.velocity.magnitude) + (rbAlvo.mass *  2.5f * transform.up)), ForceMode.Impulse);
             rb.AddForce((transform.forward * rbAlvo.mass) + (-transform.up * rbAlvo.mass));

            cooldown = 8f;
            collision.gameObject.GetComponent<CarroIA>().passado = true;
        }
    }
}
