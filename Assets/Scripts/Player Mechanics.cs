using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour {

    private bool hazard = false; // If player is over hazard, hazard = true
    private bool wizard; //Checks to see if player is wizard or warrior. Wizard = true, Warrior = false

    public Vector3 push; // A Vector 3 telling the offset to attack
    public Object fire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    // Will be called when player attacks
    public void attack()
    {
        Instantiate(fire,transform.position + push, Quaternion.identity); // Fire is placeholder for either magic attack or sword depending on class
    }
}
