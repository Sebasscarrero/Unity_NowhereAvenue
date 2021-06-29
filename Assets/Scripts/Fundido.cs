using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fundido : MonoBehaviour {


    public Image fundido;
    public string[] Escenas;
    public GameObject textoLegendario;
    public bool MuestraTexto = false;
    public bool ActivaTexto = false;


    void Start () {

        fundido.CrossFadeAlpha(0, 0.3f, false);
	}
	

    public void FadeOut(int s)
    {
        fundido.CrossFadeAlpha(1, 0.3f, false);
        StartCoroutine(CambioEscena(Escenas[s]));

        /*if (MuestraTexto == true)                   // MODO LEGENDARIO
        {
            //StartCoroutine(ApareceTextoLegendario());
            textoLegendario.SetActive(true);
        }
        */

    }

   /* public void ActivaTexto()
    {
        if (MuestraTexto == true)                   // MODO LEGENDARIO
        {
            //StartCoroutine(ApareceTextoLegendario());
            textoLegendario.SetActive(true);
        }
    }*/


    IEnumerator CambioEscena(string escena)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escena);

    }

    IEnumerator ApareceTextoLegendario()
    {
        yield return new WaitForSeconds(.2f);
        textoLegendario.SetActive(true);

    }

    private void Update()
    {
      /*  if (PlayerPrefs.GetInt("Corona", 0) == 1)                   // MODO LEGENDARIO
        {
            Debug.Log("Se mostrará el texto");
            MuestraTexto = true;
        }*/

        if (PlayerPrefs.GetInt("Corona", 0) == 1)
        {
            if (MuestraTexto == false)
            {
                StartCoroutine(ApareceTextoLegendario());
                Debug.Log("Se mostrará el texto");
                MuestraTexto = true;
                ActivaTexto = true;
            }
            return;

        }

        if (ActivaTexto == true)
        {
            StartCoroutine(ApareceTextoLegendario());
            ActivaTexto = false;
        }

    }

}
