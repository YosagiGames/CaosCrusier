using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Cacador : MonoBehaviour
{
    public GameObject carro;
    Rigidbody rb;

    float velAcumulada = 0; 
    bool noVacuo = false;

    void Start()
    {
        rb = carro.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 20f, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20f))
        {
            if(hit.collider.gameObject.transform.parent.parent.CompareTag("Carro")) 
            {
                Debug.Log("tun tun tun");
                noVacuo = true;
                velAcumulada += Time.deltaTime * 45f;
                if (velAcumulada > 450f) 
                {
                    velAcumulada = 450f;
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
                rb.AddForce(transform.forward * velAcumulada, ForceMode.Acceleration);
                velAcumulada -= Time.deltaTime * 90f;
                if (velAcumulada < 0f)
                {
                    velAcumulada = 0f;
                }
            }
        }
    }
}
