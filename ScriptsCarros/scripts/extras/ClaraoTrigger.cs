using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class ClaraoTrigger : MonoBehaviour
{
    Clarao Sol;

    public GameObject flash;
    public bool DentPiramide;
    public float cooldown;

     
   private void Start()
    {
        Sol = GameObject.Find("Codigos").GetComponent<Clarao>();
        DentPiramide = false;
        cooldown = 0;
    }
    // Update is called once per frame
    void Update()
    {
       
        cooldown -= Time.deltaTime;

        
        if (DentPiramide && cooldown <= 0)
        {
            
           StartCoroutine(Sol.Flash());
            cooldown = 25;
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.parent.parent.parent.name == "player")
        {
            if (!DentPiramide)
            {
                DentPiramide = true;
            }
            else if (DentPiramide)
            {
                DentPiramide = false;
            }
        }
    }
}
