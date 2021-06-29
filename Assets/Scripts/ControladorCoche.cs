using UnityEngine;
using System.Collections;

public class ControladorCoche : MonoBehaviour {

	public GameObject cocheGO;

	public float anguloDeGiro;
	public float velocidad;

    
    public Coche cocheScript;

    public Joystick joystick;



	// Use this for initialization
	void Start () {

		cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
       
        cocheScript = cocheGO.GetComponent<Coche>();

    }
	
	// Update is called once per frame
	void Update () {

        float giroEnZ = 0;

        if(cocheScript.ChocoCarro == false)
        {
            

            //transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);  //USANDO TECLAS



            transform.Translate(Vector2.right * joystick.Horizontal * velocidad * Time.deltaTime);  //USANDO JOYSTICK

            //giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro;   //USANDO TECLAS

            giroEnZ = joystick.Horizontal * -anguloDeGiro;        //USANDO JOYSTICK

            cocheGO.transform.rotation = Quaternion.Euler(0, 0, giroEnZ);

        }

        else
        {
            

            //transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);  //USANDO TECLAS



            transform.Translate(Vector2.right * joystick.Horizontal * 0 * Time.deltaTime);  //USANDO JOYSTICK

            //giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro;   //USANDO TECLAS

            giroEnZ = joystick.Horizontal * 0;        //USANDO JOYSTICK

            cocheGO.transform.rotation = Quaternion.Euler(0, 0, giroEnZ);
        }
	
	}
}
