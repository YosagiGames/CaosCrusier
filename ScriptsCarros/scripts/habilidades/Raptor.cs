using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Raptor : MonoBehaviour
{
    public GameObject carro;

    public Animator animator;
    public bool batida;
    Rigidbody rb;
    RaycastHit Hit;
    Slider barra;
    float cooldown = 0;
    float hp = 100f;

    float fImpacto;
    void Start()
    {
        rb = carro.GetComponent<Rigidbody>();
        barra = GameObject.Find("barra").GetComponent<Slider>();
        barra.maxValue = 100;
    }
    void FixedUpdate() {
        //Limita para que o cooldown não passe de 0
        if(cooldown <= 0)
        {
            animator.SetBool("Batida", false);
            cooldown = 0;
        }
        //Limita o HP a 100
        if(hp > 100f)
        {
            hp = 100f;
        }
        barra.value = hp; 
    }
    void Update()
    {
        fImpacto = 40f;
        cooldown -= Time.deltaTime;
        if(cooldown <= 0){
            hp += Time.deltaTime * 2.5f;
        }
    }
    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.CompareTag("Carro"))
       {

            animator.SetBool("Batida", true);
            cooldown = 5f;
            float sent;
            if(hp >= 25.5f)
            {
                Rigidbody rbAlvo = other.gameObject.GetComponent<Rigidbody>();

                if(other.gameObject.transform.position.x > carro.transform.position.x)
                {
                    sent = -1f;
                }
                else
                {
                    sent = 1f;
                }

                rbAlvo.AddForce(other.gameObject.transform.right * fImpacto * rbAlvo.mass * sent, ForceMode.Impulse);

                
                hp -= 25.5f;
                rb.AddForce(transform.forward * fImpacto / 50f, ForceMode.Acceleration) ;
            }
            else
            {
                rb.AddForce(-transform.forward * fImpacto);
            }
       }
    }
}
