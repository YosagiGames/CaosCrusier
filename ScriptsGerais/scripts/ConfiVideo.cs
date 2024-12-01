using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfiVideo : MonoBehaviour
{
    float tempo;
    void Start()
    {
        tempo = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

        if(tempo > 14f) 
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
