using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SliderConfig : MonoBehaviour
{
    public Slider audioJogo; 
    public Slider brilhoJogo;
    public Slider musicaJogo;

    float musica;
    float volume;
    float brilho = 1f;

    public PostProcessProfile profile;
    public PostProcessLayer layer;

    AutoExposure exposure;

    AudioSource soundTrack;

    void Start()
    {
        // procurando gameobject da soundtrack da fase
        soundTrack = GameObject.Find("SoundTrack").GetComponent<AudioSource>();

        // instanciando os valores que serão alterados do brilho
        profile.TryGetSettings(out exposure);
        AjustarBrilho();

        // mantendo valor do audio do jogo a partir da informação armmazenada na maquina;

        volume = PlayerPrefs.GetFloat("audioJogo");

        audioJogo.value  = volume;

        AudioListener.volume = volume;


        // mantendo valor do brilho a partir da informação armmazenada na maquina;
        brilho = PlayerPrefs.GetFloat("brilhoJogo");

        brilhoJogo.value = brilho;

        exposure.keyValue.value = brilho;

        // mantendo valor da musica a partir da informação armmazenada na maquina;
        musica = PlayerPrefs.GetFloat("musicaJogo");

        musicaJogo.value = musica;

        soundTrack.volume = musica;
    }

    // Update is called once per frame
    void Update()
    {
        // definindo valor do slider do volume do jogo
        volume = audioJogo.value;
        // guardando informação na maquina
        PlayerPrefs.SetFloat("audioJogo", volume);

        AudioListener.volume = volume;

        // definindo valor do slider do brihlo do jogo
        brilho = brilhoJogo.value;

        PlayerPrefs.SetFloat("brilhoJogo", brilho);
        exposure.keyValue.value = brilho;

        // definindo valor do slider do volume da musica
        musica = musicaJogo.value;

        PlayerPrefs.SetFloat("musicaJogo", musica);

        soundTrack.volume = musica;


    }
    public void AjustarBrilho()
    {
        exposure.keyValue.value = brilho;
       
    }
   

    
}