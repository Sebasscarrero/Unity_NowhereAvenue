using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCarretera : MonoBehaviour {

    public float Velocidad;
    public bool InicioJuego;
    public bool FinJuego;
    public GameObject ContendedorCallesGO;
    public GameObject[] ContenedorCallesARRAY;
    int ContCalles = 0;
    int CalleRandom;
    public GameObject CalleAnterior;
    public GameObject CalleSiguiente;
    public float TamañoCalle;
    public Vector3 MedidaLimitePantalla;
    public bool SalioDePantalla;
    
    public GameObject miCamara;
    public Camera CompMiCamara;
    public GameObject CarroGO;
    public GameObject FXMusica;
    public FXSounds FXMusicaSCRIPT;
    public GameObject PanelGameOver;
   // public GameObject BusGeneratorGO;
   // public LevelGenerator BusGeneratorSCRIPT;
   


    void Start () {

        StartJuego();   
	}
	

    void StartJuego ()
    {
        //VelocidadCarretera();
        CompMiCamara = miCamara.GetComponent<Camera>();

        PanelGameOver = GameObject.Find("PanelGameOver");
        PanelGameOver.SetActive(false);

        FXMusicaSCRIPT = FXMusica.GetComponent<FXSounds>();
       // BusGeneratorSCRIPT = BusGeneratorGO.GetComponent<LevelGenerator>();



        MedirPantalla();
        BuscoCalles();

    }

    public void GameOver()
    {

        CarroGO.GetComponent<AudioSource>().Stop();
        FXMusicaSCRIPT.FXMusica();
        PanelGameOver.SetActive(true);


    }

    void BuscoCalles()
    {
        ContenedorCallesARRAY = GameObject.FindGameObjectsWithTag("Calle");
        for (int i =0; i < ContenedorCallesARRAY.Length; i++)
        {
            ContenedorCallesARRAY[i].gameObject.transform.parent = ContendedorCallesGO.transform;
            ContenedorCallesARRAY[i].gameObject.SetActive(false);
            ContenedorCallesARRAY[i].gameObject.name = "CarreteraOff_" + i;
        }
        CrearCalle();
    }

    void CrearCalle()
    {
        //BusGeneratorSCRIPT.BusRandom();
        ContCalles++;
        CalleRandom = Random.Range(0, ContenedorCallesARRAY.Length);
        GameObject Calle = Instantiate(ContenedorCallesARRAY[CalleRandom]);
        Calle.SetActive(true);
        Calle.name = "Calle" + ContCalles;
        Calle.transform.parent = gameObject.transform;
        PosicionoCalles();
    }

    void PosicionoCalles()
    {
        
        CalleAnterior = GameObject.Find("Calle" + (ContCalles - 1));
        CalleSiguiente = GameObject.Find("Calle" + (ContCalles));
        MidoCalle();
        CalleSiguiente.transform.position = new Vector3(CalleAnterior.transform.position.x, CalleAnterior.transform.position.y + TamañoCalle, 0);
        SalioDePantalla = false;
    }

    void MidoCalle()
    {

        for (int i = 0; i < CalleAnterior.transform.childCount; i++)
        {
            if (CalleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
            float tamañoPieza = CalleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
            TamañoCalle = TamañoCalle + tamañoPieza - 0.17f;
        }
    }

    }

    void MedirPantalla()
    {
        MedidaLimitePantalla = new Vector3(0, CompMiCamara.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }


    void DestruyoCalles()
    {
        
        Destroy(CalleAnterior);
        TamañoCalle = 0;
        CalleAnterior = null;
        CrearCalle();
    }

    void VelocidadCarretera()
    {

        //Velocidad=18;
    }

	void Update () {

        if (InicioJuego == true && FinJuego == false) {

            Velocidad += 0.001f;

              transform.Translate(Vector3.down * Velocidad * Time.deltaTime);
            if (CalleAnterior.transform.position.y + TamañoCalle < MedidaLimitePantalla.y && SalioDePantalla == false)
            {
                SalioDePantalla = true;
                DestruyoCalles();
            }
        }
    }
}
