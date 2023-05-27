using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioGeneral;
    public AudioMixerGroup musica, efectos;

    public AudioSource MusicaTienda,Agarrar, Despide, Destornillador, Dinero;

    public static AudioManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    public void StopAudio(AudioSource audio)
    {
        audio.Stop();
    }
}
