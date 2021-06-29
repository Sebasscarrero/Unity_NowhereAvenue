using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSounds : MonoBehaviour {

    public AudioClip[] Sonidos;
    public AudioSource AudioS;

    private void Start()
    {

        AudioS = GetComponent<AudioSource>();
    }


   public void FXChoque()
    {
        AudioS.clip = Sonidos[0];
        AudioS.Play();

    }

    public void FXMusica()
    {
        AudioS.clip = Sonidos[1];
        AudioS.Play();
       

    }

    public void CorrectTimer()
    {
        AudioS.clip = Sonidos[2];
        AudioS.Play();


    }

    public void WrongTimer()
    {
        AudioS.clip = Sonidos[3];
        AudioS.Play();


    }

    

}
