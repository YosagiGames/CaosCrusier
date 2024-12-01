using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiChuva : MonoBehaviour
{
    public GameObject chuva;
    float cooldown;
     
   private bool AtChuva;
    void Start()
    {
        chuva.SetActive(false);
        AtChuva = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.transform.parent.parent.gameObject.name);
        if (other.gameObject.transform.parent.parent.parent.name == "player")  
        {
            if (!AtChuva && cooldown <= 0)
            {
                Debug.Log("passou");
                AtChuva = true;
                chuva.SetActive (true);
                cooldown = 2f;
                RenderSettings.fog = true;
            }


            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.transform.parent.parent.gameObject.name);
        if (other.gameObject.transform.parent.parent.parent.name == "player")

            if (AtChuva && cooldown <= 0)
            {

            AtChuva = false;
            chuva.SetActive(false);
            cooldown = 2f;
            RenderSettings.fog = false;

            }

    }
}
