using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiChuva : MonoBehaviour
{
    public GameObject chuva;
     
   private bool AtChuva;
    void Start()
    {
        chuva.SetActive(false);
        AtChuva = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chuva"))  {
            if (!AtChuva)
            {
                Debug.Log("passou");
                AtChuva = true;
                chuva.SetActive (true);
            }
            else
            {
                AtChuva = false;
                chuva.SetActive (false);
            }
        
        }
    }
}
