using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro1 : MonoBehaviour {


  
     float Tiempo;
     float Distancia;
     Text txtTiempo;
     Text txtDistancia;
     Text txtDistanciaFinal;
    public Text txtHighScore;

    public GameObject Corona;
    public bool MaxAlcanzado = false;
    public bool Max1 = false;
    public bool Max2 = false;
    public AudioSource AudioHurra;
    public AudioSource FinVoz;

    public GameObject CoronaSombraRoja;
    public GameObject CoronaRoja;

    public Text verde;
    public Text rojo;

    void Start () {

        

        txtHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //PlayerPrefs.SetInt("Corona", 0);
        //PlayerPrefs.SetInt("CoronaRoj", 0);
    }
	
    void CalculoTiempoDistacia()
    {
        
       

        txtDistancia.text = ((int)Distancia).ToString() ;  // Texto con el puntaje del jugador

        Tiempo -= Time.deltaTime;
        int minutos = (int)Tiempo / 60;
        int segundos = (int)Tiempo % 60;

        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');

        if ((int)Distancia > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)Distancia);
            txtHighScore.text = ((int)Distancia).ToString() + "";
        }

       



    }

    public void reset()
    {
        Debug.Log("Borró info");
       // PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteAll();
        txtHighScore.text = "0";

    }

   public void BotonCorona()
    {
        AudioHurra.Play();

    }
    public void BotonCoronaRojo()
    {
        FinVoz.Play();

    }

    public void ApareceVerde()
    {

        if (PlayerPrefs.GetInt("HighScore", 0) >= 1220 && PlayerPrefs.GetInt("HighScore", 0) < 2001  && Max1 == false)
        {         
                PlayerPrefs.SetInt("Corona", 1);
                Max1 = true;            
         }


        if (PlayerPrefs.GetInt("Corona", 0) == 1)
        {
            
            Corona.SetActive(true);
            CoronaSombraRoja.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Corona", 0) == 0 )
        {
            Corona.SetActive(false);
            CoronaSombraRoja.SetActive(false);
        }


    }

    public void ApareceRojo()
    {

        if (PlayerPrefs.GetInt("HighScore", 0) >= 2001 && Max2 == false)
        {
            PlayerPrefs.SetInt("CoronaRoj", 1);
            Max2 = true;
        }


        if (PlayerPrefs.GetInt("CoronaRoj", 0) == 1)
        {
          
            CoronaRoja.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("CoronaRoj", 0) == 0)
        {
            CoronaRoja.SetActive(false);
        }

    }


    private void Update()
    {

        ApareceVerde();
        ApareceRojo();

        verde.text = PlayerPrefs.GetInt("Corona").ToString();
        rojo.text = PlayerPrefs.GetInt("CoronaRoj").ToString();

     
         
    }
}







