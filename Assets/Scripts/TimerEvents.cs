using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEvents : MonoBehaviour {

   
   
    public GameObject CronometroGO;
    public Cronometro CronometroSCRIPT;
    public GameObject TipoRelojGO;
    public Time_Item TipoReloj;
    public bool AddReloj;
    public SpriteRenderer TipoSprite;
    public Sprite[] SpritesReloj;
    public GameObject FXMusica;
    public FXSounds FXMusicaSCRIPT;
    

    //public AudioClip[] SonidosClock;
    //public AudioSource AudioClock;


    void Start()
    {

        //AudioClock = GetComponent<AudioSource>();
        FXMusica = GameObject.Find("FXSounds");
        FXMusicaSCRIPT = FXMusica.GetComponent<FXSounds>();

        CronometroGO = GameObject.Find("Cronometro");
        CronometroSCRIPT = CronometroGO.GetComponent<Cronometro>();
        TipoRelojGO = GameObject.FindGameObjectWithTag("TimeSpawn");
        TipoReloj = TipoRelojGO.GetComponent<Time_Item>();
        TipoSprite = GetComponent<SpriteRenderer>();

        TipoRelojAdd();
    }

    void TipoRelojAdd()
    {

        if (TipoSprite.sprite == SpritesReloj[0])
        {
            AddReloj = true;
        }
        else if (TipoSprite.sprite == SpritesReloj[1])
        {
            AddReloj = false;
        }
    }
   



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<Coche>() != null && AddReloj == true)
        {
            FXMusicaSCRIPT.CorrectTimer();
            CronometroSCRIPT.Tiempo += 10;
            
           
            Destroy(this.gameObject);
        }
            
        else if (other.GetComponent<Coche>() != null && AddReloj == false)
            {

            FXMusicaSCRIPT.WrongTimer();
            CronometroSCRIPT.Tiempo -= 13;
            
            
            Destroy(this.gameObject);
            }
    }



    private void Update()
    {
        
        if (this.gameObject.transform.position.y <= -7.0)
        {
            Destroy(this.gameObject);
        }


    }



}
