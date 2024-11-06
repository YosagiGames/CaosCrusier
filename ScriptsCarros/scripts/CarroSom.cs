using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroSom : MonoBehaviour
{
    public float MaxPitch;
    public float MinPitch;

    public AudioSource AudioCarro;
    public Rigidbody Carro;
    void Start()
    {
        Carro = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioCarro.pitch = MinPitch + (Carro.velocity.magnitude * 3.6f) / 300;
        if (AudioCarro.pitch > MaxPitch)
        {
            AudioCarro.pitch = MaxPitch;
        }
    }
}
