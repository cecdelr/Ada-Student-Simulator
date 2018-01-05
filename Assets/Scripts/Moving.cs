using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {
    void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash("x", 4, 
                                              "easeType", "linear", 
                                              "loopType", "pingPong", 
                                              "delay", 1,
                                              "speed", 2));
    }
}
