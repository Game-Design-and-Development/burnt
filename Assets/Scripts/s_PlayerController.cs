using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Math;

/**
 * player controller
 * handles player input, player movement. player collisions with objects.
 * @author Ryan Thorne
 */

public class s_PlayerController : MonoBehaviour {

	//speed/directional values
	Vector2 IN;
	public uint MAX_DIRECTIONAL_SPEED; // all caps should be readonly, unsure if i can get away with it at this point :)
	public float DIRECTIONAL_DEADZONE;
	protected float zero_speed = 0.0f;
	
	
	//collision data
	protected LayerMask l_enemy;
	protected LayerMask l_wall;
	protected LayerMask l_goal;
	protected LayerMask l_hazard;
	protected RaycastHit2D[] hitbuffer;
	protected Rigidbody2D collision_detector = null;
	protected ContactFilter2D filter = new ContactFilter2D();

	//using onEnable in case object is not created as sscene starts?
	void OnEnable()
    {
        collision_detector = GetComponent<Rigidbody2D> ();
		hitbuffer = new RaycastHit2D[16];
		l_enemy = LayerMask.GetMask("Enemy");
		l_wall = LayerMask.GetMask("Wall");
		l_goal = LayerMask.GetMask("Goal");
		l_hazard = LayerMask.GetMask("Hazard");
    }
	
	// Update is called once per frame
	void Update () {
		read_input();
		//refine movement
		float speed = Time.deltaTime * MAX_DIRECTIONAL_SPEED;
		IN *= speed;
		
		//resolve collisions
		
		int hits;
		//3 collisions: with enemies/hazards (dynamic), with walls, (cancel move), with goals (triggering)
		
		filter.SetLayerMask(l_wall);
		if((hits = collision_detector.Cast(IN , filter, hitbuffer, speed)) > 0)
		//collision with wall means we can cozy up to it and then cancel movement parrallel to the collision direction
		{
			for(int i = 0; i < hits; i++)
			{
				//find the length of the compnent of the vector that is parrallel to the norm of the collision: subtract that from our movement vector
				IN = IN - hitbuffer[i].normal * speed * hitbuffer[i].fraction;
			}
		}
		
		filter.SetLayerMask(l_enemy);
		if((hits = collision_detector.Cast(IN , filter, hitbuffer, speed)) > 0)
		//resolve enemy collision results on movement
		{
			
		}
		
		filter.SetLayerMask(l_hazard);
		if((hits = collision_detector.Cast (IN, filter, hitbuffer, speed)) > 0)
		{
			
		}
		
		
		filter.SetLayerMask(l_goal);
		if((hits = collision_detector.Cast (IN, filter, hitbuffer, speed)) > 0)
		{
			
		}
		
		//result 
		
		//actually translate object
		
		transform.Translate(IN);
	}
	
	void read_input()
	{
		IN.x = Input.GetAxis("horizontal");
		if(Mathf.Abs(IN.x) < DIRECTIONAL_DEADZONE)
			IN.x = zero_speed;
		IN.y = Input.GetAxis("vertical");
		if(Mathf.Abs(IN.y) < DIRECTIONAL_DEADZONE)
			IN.y = zero_speed;
	}
}
