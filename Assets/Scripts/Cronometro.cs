using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {


    public GameObject Controlador_MC;
    public MovimientoCarretera Controlador_MC_Script;
    public float Tiempo;
    public float Distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciaFinal;
    public Text txtHighScore;
    public Text txtMasterHighScore;

    public bool TicToc = false;

    public AudioSource AudioTictoc;

    public Text TextoLegend;

    public bool Max = false;

    public Color colorVerde;
    public Color colorRojo;

    public GameObject cocheGO;
    public Coche cocheScript;


    void Start () {

        Controlador_MC_Script = Controlador_MC.GetComponent<MovimientoCarretera>();

        txtTiempo.text = "1:00";
        txtDistancia.text = "0";

        cocheGO = GameObject.Find("Player");
        cocheScript = cocheGO.GetComponent<Coche>();

        cocheScript.GetComponent<Collider2D>().enabled = true;

        AudioTictoc = GetComponent<AudioSource>();

        txtHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        txtMasterHighScore.text = PlayerPrefs.GetInt("HighScoreMAESTRO", 1220 ).ToString()+ " m";
        TextoLegend.text = PlayerPrefs.GetInt("HighScoreLEGEND", 2001).ToString() + " m";
    }
	
    void CalculoTiempoDistacia()
    {
        
        Distancia += Time.deltaTime * Controlador_MC_Script.Velocidad;  // Puntaje del jugador

        txtDistancia.text = ((int)Distancia).ToString() ;  // Texto con el puntaje del jugador

        Tiempo -= Time.deltaTime;
        int minutos = (int)Tiempo / 60;
        int segundos = (int)Tiempo % 60;

        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');

        if ((int)Distancia > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)Distancia);
            txtHighScore.text = ((int)Distancia).ToString();
        }
        if ((int)Distancia > PlayerPrefs.GetInt("HighScoreMAESTRO", 1220) || PlayerPrefs.GetInt("Corona",0) == 1)
        {

            // PlayerPrefs.SetInt("HighScoreMAESTRO", (int)Distancia);    //ALMACENA PUNTAJE MAXIMO MAESTRO         
            // txtMasterHighScore.text = ((int)Distancia).ToString();

            txtMasterHighScore.color = colorVerde;
            txtMasterHighScore.text = "1220 m ✔";
        }
        /*else
        {
            txtMasterHighScore.color = colorRojo;
        }*/
        if ((int)Distancia > PlayerPrefs.GetInt("HighScoreLEGEND", 2001) || PlayerPrefs.GetInt("CoronaRoj", 0) == 1)
        {

            // PlayerPrefs.SetInt("HighScoreMAESTRO", (int)Distancia);    //ALMACENA PUNTAJE MAXIMO MAESTRO         
            // txtMasterHighScore.text = ((int)Distancia).ToString();

            TextoLegend.color = colorVerde;
            TextoLegend.text = "2001 m ✔";
        }
       /* else
        {
            txtMasterHighScore.color = colorRojo;
        }*/

        /* if (PlayerPrefs.GetInt("HighScore", 0) >= 1220)                   // MODO LEGENDARIO
          {
              if (Max == false)
              {
                  PlayerPrefs.SetInt("Corona2", 1);
                  Max = true;
                  // MaxAlcanzado = true;
              }
              return;
          }

      */




    }

    void SonidoTicToc()
    {

        if (Tiempo <= 14)
        {
            if (TicToc == false)
            {
                AudioTictoc.Play();
                Debug.Log("TicToc");
                TicToc = true;
            }
            return;
        }

        if (Tiempo > 14)
        {
            if (TicToc == true)
            {
                AudioTictoc.Stop();
                TicToc = false;
            }
            return;
        }





    }   


	void Update () {

        if(Controlador_MC_Script.InicioJuego == true && Controlador_MC_Script.FinJuego == false)
        {
         CalculoTiempoDistacia();
            SonidoTicToc();

        }
        
        if (Tiempo < 1 && Controlador_MC_Script.FinJuego == false)
        {
            AudioTictoc.Stop();
            Controlador_MC_Script.FinJuego = true;
            Controlador_MC_Script.GameOver();
            cocheScript.GetComponent<Collider2D>().enabled = false;
            txtDistanciaFinal.text = ((int)Distancia).ToString() + " m";
            txtTiempo.text = "0:00";
            txtTiempo.color = colorRojo;
        }

        
    }
}
