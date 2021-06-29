using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour {

    public bool ChocoCarro = false;
    public GameObject ExplosionCarro;

     void Update()
    {
        
        if(ChocoCarro == true)
        {

            Instantiate(ExplosionCarro, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            ChocoCarro = false;
        }

    }


}
