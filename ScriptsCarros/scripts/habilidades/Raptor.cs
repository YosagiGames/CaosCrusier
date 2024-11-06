using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raptor : MonoBehaviour
{
    public GameObject carro;

    Rigidbody rb;
    RaycastHit Hit;

    float cooldown = 0;
    float hp = 100f;

    float fImpacto;
    void Start()
    {
        rb = carro.GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        //Limita para que o cooldown não passe de 0
        if(cooldown <= 0)
        {
            cooldown = 0;
        }
        //Limita o HP a 100
        if(hp > 100f)
        {
            hp = 100f;
        }
    }
    void Update()
    {
        fImpacto = (Mathf.Pow(Mathf.Floor(rb.velocity.magnitude * 3.6f), 2f) * rb.mass) / 26f;
        if (fImpacto < 8000)
        {
            fImpacto = 8000f;
        }
        cooldown -= Time.deltaTime;
        if(cooldown <= 0){
            hp += Time.deltaTime * 2.5f;
        }
    }
    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.CompareTag("Carro"))
       {
            float sent;
            if(hp >= 25.5f)
            {
                Rigidbody rbAlvo = other.gameObject.GetComponent<Rigidbody>();

                if(other.gameObject.transform.position.x > carro.transform.position.x)
                {
                    sent = 1f;
                }
                else
                {
                    sent = -1f;
                }

                rbAlvo.AddForce(other.gameObject.transform.right * fImpacto * 6f *  sent);

                cooldown = 5f;
                hp -= 25.5f;
                rb.AddForce(transform.forward * fImpacto);
            }
            else
            {
                rb.AddForce(-transform.forward * fImpacto);
            }
       }
    }
}
