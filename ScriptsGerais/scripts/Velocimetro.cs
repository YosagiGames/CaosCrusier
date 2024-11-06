using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
public class Velocimetro : MonoBehaviour
{

  
    public CarroJogador jogador = new CarroJogador();

    public float rpmMaxPont;
   
  
    public float velocidade;
    float rpm;
    int marcha;

    public TMPro.TMP_Text NumMarcha;
    public TMPro.TMP_Text Veloci;

    public float velCar;
    public GameObject carro;

    public Transform pont;
    // Start is called before the first frame update
    void Start()
    {
        NumMarcha = GameObject.Find("marcha").GetComponent<TMP_Text>();
        Veloci  = GameObject.Find("velocidade").GetComponent<TMP_Text>();
        pont = GameObject.Find("PONT").transform;
    }
    // Update is called once per frame
    void Update()
    {
            rpm = carro.GetComponent<CarroJogador>().Rpm;
            marcha = carro.GetComponent<CarroJogador>().Marcha + 1;
            velCar = Mathf.Floor(GetComponent<Rigidbody>().velocity.magnitude * 3.6f);
        
        if (pont != null)
        {
            pont.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(0, (rpm / rpmMaxPont) * (6000 / (2000 + (carro.GetComponent<CarroJogador>().lvlVel * 500))), 3));
            NumMarcha.text = marcha.ToString();
            Veloci.text = velCar.ToString(); 
        }

    }
}
