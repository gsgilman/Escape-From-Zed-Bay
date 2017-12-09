using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour {

    [HideInInspector]
    public bool isTriggered;
    public Collider2D otherCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
        otherCollider = other;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        isTriggered = true;
        otherCollider = other;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }


    // Use this for initialization
    void Start () {
        isTriggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
