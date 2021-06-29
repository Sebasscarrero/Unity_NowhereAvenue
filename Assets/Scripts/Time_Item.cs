using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Item : MonoBehaviour {

    public GameObject[] TimeIcons;
    public int rand; //Cambia icono tiempo
  
    public int randTime;

    public bool StopSpawning = false;
    public float SpawnTime;
    public float SpawnDelay;

    public GameObject Controlador_MC;
    public MovimientoCarretera Controlador_MC_Script;


    void Start()
    {

        Controlador_MC_Script = Controlador_MC.GetComponent<MovimientoCarretera>();
        //randTime = Random.Range(10, 15);

       

        InvokeRepeating("CreaObjetoReloj", SpawnTime, SpawnDelay);



    }


    void CreaObjetoReloj()
    {
        //SpawnTime = Random.Range(1, 3);
        //SpawnDelay = Random.Range(5, 10);


        if (Controlador_MC_Script.FinJuego == false)
        {
 rand = Random.Range(0, 10);

        //Crea un reloj que aumenta tiempo
        if (rand == 0 || rand == 1 )
        {
            Instantiate(TimeIcons[0], transform.position, Quaternion.identity);
           
        }

        //Crea un reloj que resta tiempo
        if (rand == 2 || rand == 3 || rand == 4 || rand == 5 || rand == 6)
        {
            Instantiate(TimeIcons[1], transform.position, Quaternion.identity);
                
        }
        }



       

    } 
   
    

   


}

