using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

    public Animator CamAnim;

    public void CameraShake()
    {
        Handheld.Vibrate();
        CamAnim.SetTrigger("Shake");
    }


}
