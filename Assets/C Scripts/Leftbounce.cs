using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leftbounce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	      
        // Zou mooi zijn als bij raken van deze trigger de ball weg bounce't
        void OnTriggerEnter2D(Collider2D trigger)
        {
        Debug.Log("Left ear op paddle has been hit");
    }
    
}
