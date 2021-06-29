using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour {

    public GameObject MovimientoCarreteraGO;
    public MovimientoCarretera MovimientoCarreteraSCRIPT;
    public Sprite[] Numeros;
    public GameObject ContNumerosGO;
    public SpriteRenderer ContNumerosComp;
    public GameObject ControladorCarro;
    public GameObject Carro;


	void Start () {
        InicializarVariables();
	}


    void InicializarVariables()
    {
        MovimientoCarreteraSCRIPT = MovimientoCarreteraGO.GetComponent<MovimientoCarretera>();
        ContNumerosComp = ContNumerosGO.GetComponent<SpriteRenderer>();
        IniciaCuentaAtras();
    }

    void IniciaCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        
        ControladorCarro.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        ContNumerosComp.sprite = Numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        ContNumerosComp.sprite = Numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        ContNumerosComp.sprite = Numeros[3];
        ContNumerosComp.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(.2f);
        MovimientoCarreteraSCRIPT.InicioJuego = true;
        Carro.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        ContNumerosGO.SetActive(false);


    }









    void Update () {
		
	}
}
