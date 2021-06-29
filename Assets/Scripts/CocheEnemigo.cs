using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheEnemigo : MonoBehaviour {




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coche>() != null)
        {
            Destroy(this.gameObject);
        }


    }

     

}
