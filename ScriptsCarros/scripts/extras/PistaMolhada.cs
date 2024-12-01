using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistaMolhada : MonoBehaviour
{
    public WheelCollider RodaRua;
    public WheelCollider RodaEscorrega;
    float cooldown;
    public bool chuva;
    private GameObject Carro;



    private void Start()
    {
        
        chuva = false;

    }

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

       
        
            Carro = other.gameObject.transform.parent.parent.gameObject;
            for (int i = 0; i < Carro.transform.Find("pneus").childCount; i++)
            {
                Carro.transform.Find("pneus").GetChild(i).GetComponent<WheelCollider>().sidewaysFriction = RodaEscorrega.sidewaysFriction;
                Debug.Log(RodaEscorrega.sidewaysFriction);

                chuva = true;

                
               
            }
        



    }
    private void OnTriggerExit(Collider other)
    {
      
            Carro = other.gameObject.transform.parent.parent.gameObject;
        for (int i = 0; i < Carro.transform.Find("pneus").childCount; i++)
        {
            Carro.transform.Find("pneus").GetChild(i).GetComponent<WheelCollider>().sidewaysFriction = RodaRua.sidewaysFriction;
            Debug.Log(RodaRua.sidewaysFriction);
            chuva = false;
            

        }
    }
}
