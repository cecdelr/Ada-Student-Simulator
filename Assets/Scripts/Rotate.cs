using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    void Start()
    {
        iTween.RotateBy(gameObject, iTween.Hash("x", .25, 
                                                "easeType", "easeInOutBack", 
                                                "loopType", "pingPong", 
                                                "delay", .1));
    }
}
