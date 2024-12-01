using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vento : MonoBehaviour
{
    public float forca;
    float mod;
    GameObject carro;
    private void OnTriggerEnter(Collider other)
    {
        mod = Random.Range(1f, 1.5f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.parent.CompareTag("Carro")){
            carro = other.transform.parent.parent.gameObject;
            Debug.Log("Força aplicada: " + forca * mod);
            carro.GetComponent<Rigidbody>().AddForce((transform.right - transform.up) * forca * mod, ForceMode.Impulse);
        }
    }
}
