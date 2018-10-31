using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * player controller
 * handles player input, player movement. player collisions with objects.
 * @author Ryan Thorne
 */

public class playerController : MonoBehaviour {

	Vector3 IN;
	public int MAX_DIRECTIONAL_SPEED; // all caps should be readonly, unsure if i can get away with it at this point :)
	public float DIRECTIONAL_DEADZONE;
	protected Rigidbody2D collision_detector = null;

	//using onEnable in case object is not created as sscene starts?
	void OnEnable()
    {
        collision_detector = GetComponent<Rigidbody2D> ();
    }
	
	// Update is called once per frame
	void Update () {
		read_input();
		//refine movement
		IN *= Time.deltaTime * MAX_DIRECTIONAL_SPEED;
		
		//resolve collisions
		
		
		//actually translate object
		
		transform.translate(IN);
	}
	
	void read_input()
	{
		IN.x = Input.GetAxis("horizontal");
		if(Math.Abs(IN.x) < DIRECTIONAL_DEADZONE)
			IN.x = zero_speed;
		IN.y = Input.GetAxis("vertical");
		if(Math.Abs(IN.y) < DIRECTIONAL_DEADZONE)
			IN.y = zero_speed;
	}
}
