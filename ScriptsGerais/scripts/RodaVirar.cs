using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaVirar : MonoBehaviour
{

    CarroJogador joga = new CarroJogador();
    public Transform[] pneu;



    public WheelCollider[] rodas;
    void Start()
    {

       joga.rodas = rodas;
      
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rodas.Length; i++)
        {
            Quaternion quat;
            Vector3 pos;
            rodas[i].GetWorldPose(out pos, out quat);
            pneu[i].rotation = quat;

        }

    }
}
