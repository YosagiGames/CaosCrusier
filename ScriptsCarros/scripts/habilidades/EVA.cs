using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EVA : MonoBehaviour
{
    public GameObject carro;

    Rigidbody rb;
    Slider barra;
    float vapor = 5f;
    float cooldown = 10f;

    void Start()
    {
        rb = carro.GetComponent<Rigidbody>();
        barra = GameObject.Find("barra").GetComponent<Slider>();
        barra.maxValue = 5;
    }

    private void FixedUpdate()
    {
        barra.value = vapor;
    }
    void Update()
    {
        
        if(Input.GetKey(KeyCode.LeftShift) && vapor >0)
        {

            rb.AddForce(transform.forward * 250f, ForceMode.Impulse);
            Debug.Log("turbo");
            vapor -= Time.deltaTime;
            cooldown = 10f;
        }

        cooldown -= Time.deltaTime;
        if (cooldown < 0)
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
