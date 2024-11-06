using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVA : MonoBehaviour
{
    public GameObject carro;

    Rigidbody rb;
    float vapor = 5f;
    float cooldown = 10f;

    void Start()
    {
        rb = carro.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.E) && vapor > 0)
        {
            rb.AddForce(transform.forward * 45f, ForceMode.Impulse);
            vapor -= Time.deltaTime;
            cooldown = 10f;
        }
        cooldown -= Time.deltaTime;
        if(cooldown < 0)
        {
            cooldown = 0;
        }
        if(vapor != 10f && cooldown <= 0)
        {
            vapor += Time.deltaTime / 2f;
            if(vapor > 5f){
                vapor = 5f;
            }
        }
    }
}
