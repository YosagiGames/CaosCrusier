using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguirchuva : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("posicao").transform.parent;
    }

   
    void Update()
    {
        transform.position = new Vector3(player.position.x, 20 ,player.position.z);

    }
}
