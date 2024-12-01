using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDoDIa : MonoBehaviour
{
    public Transform LuzDia;
    [SerializeField] private int duracao;

    public Light forca;
    private float segundos;
    private float multi;

    public float direcaoSolY;
    public float anguloSolZ;
    
    float MomentoDiaX;
    // Start is called before the first frame update
    void Start()
    {
        multi = 86400 / duracao;
   
    
    }

    // Update is called once per frame
    void Update()
    {
        segundos += Time.deltaTime * multi;

        if(segundos >= 86400) {
            segundos = 0;
        }

        
        PassarDia();
    }

    private void PassarDia()
    {

        
         MomentoDiaX = Mathf.Lerp(-90,270, segundos / 86400);
        LuzDia.rotation = Quaternion.Euler(MomentoDiaX,direcaoSolY,anguloSolZ);

        if(MomentoDiaX >= 195)
        {

            forca.intensity = 0.0f;
           
        } 
       else if(MomentoDiaX >= -19)
        {
            forca.intensity = 1.5f;
        }
    }
}
