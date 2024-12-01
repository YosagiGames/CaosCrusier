using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NevoaFases : MonoBehaviour
{
    public float velocidade;
    public float demora;
    public float duracao;
    public Color cor;
    float cooldown;
    bool avanco = false;

    void Start()
    {
        RenderSettings.fog = false;
        RenderSettings.fogColor = cor;
        cooldown = demora;
    }

    void FixedUpdate()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }

        if (cooldown < 0f && RenderSettings.fogDensity <= 0f)
        {
            avanco = true;
            RenderSettings.fog = true;
        }


        if (RenderSettings.fogDensity > 0.09f)
        {
            avanco = false;
        }
    }

    private void Update()
    {
        

        if (avanco)
        {
            RenderSettings.fogDensity += Time.deltaTime / velocidade;
        }
        else if (!avanco && cooldown <= 0f)
        {
            RenderSettings.fogDensity -= Time.deltaTime / velocidade;
            if (RenderSettings.fogDensity < 0f)
            {
                cooldown = demora;
            }
        }
    }

}

