using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class Cacador : MonoBehaviour
{
    public GameObject carro;
    Rigidbody rb;

    Slider barra;
    public AnimationCurve impulse;
    float velAcumulada = 0; 
    bool noVacuo = false;

    void Start()
    {
        rb = carro.GetComponent<Rigidbody>();
        barra = GameObject.Find("barra").GetComponent<Slider>();    
        barra.maxValue = 45;
    }

    void FixedUpdate()
    {
        barra.value = velAcumulada;
        Debug.DrawLine(transform.position, transform.position + transform.forward * 35f, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20f))
        {
            if(hit.collider.gameObject.transform.parent.parent.CompareTag("Carro")) 
            {
                Debug.Log("tun tun tun");
                noVacuo = true;
                velAcumulada += Time.deltaTime * 4.5f;
                if (velAcumulada > 45f) 
                {
                    velAcumulada = 45f;
                }
            }
        }
        else
        {
            noVacuo = false;
        }

        if (!noVacuo)
        {
            if (velAcumulada > 0)
            {
                rb.AddForce(transform.forward * impulse.Evaluate(velAcumulada), ForceMode.Acceleration);
                velAcumulada -= Time.deltaTime * 9f;
                if (velAcumulada < 0f)
                {
                    velAcumulada = 0f;
                }
            }
        }
    }
}
