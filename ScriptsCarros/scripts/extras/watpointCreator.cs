using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watpointCreator : MonoBehaviour
{
    public GameObject waypoint;
    public GameObject carro;

    bool criar = false;
    public void Start()
    {

    }
    IEnumerator colocar()
    {
        yield return new WaitForSeconds(1.2f);
        GameObject way = Instantiate(waypoint, transform.position, Quaternion.identity);
        way.GetComponent<Caminho>().velRecomendada = carro.GetComponent<Rigidbody>().velocity.magnitude * 1.02f;

        if (criar)
        {
            StartCoroutine(colocar());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            criar = !criar;

            if (criar) { 
                StartCoroutine (colocar());
            }
        }
    }
}
