using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public Sprite[] buses;
    public GameObject BusesGO;
    public SpriteRenderer BusesCOMP;
    public GameObject CronometroGO;
    public Cronometro CronometroSCRIPT;

    public GameObject cocheGO;
    public Coche cocheScript;

    public Shake shake;

    void Start()
    {

        CronometroSCRIPT = CronometroGO.GetComponent<Cronometro>();
        cocheGO = GameObject.Find("Player");
        cocheScript = cocheGO.GetComponent<Coche>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        //----------------------------------------------------------------------------------------------------------------------

        int randBus = Random.Range(0, buses.Length);
        int randActive = Random.Range(0, 3);
        // BusesCOMP = BusesGO.GetComponent<SpriteRenderer>();
        BusesCOMP.sprite = buses[randBus];

        if (randActive == 1 || randActive == 2)
        {
            BusesGO.SetActive(true);
        }

        else
        {
            BusesGO.SetActive(false);
        }

    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coche>() != null)
        {
            shake.CameraShake();

            cocheScript.ChocoCarro = true;

            CronometroSCRIPT.Tiempo = 0;

            //Destroy(this.gameObject);
        }
        else
        {
            cocheScript.ChocoCarro = false;
        }


    }




}
