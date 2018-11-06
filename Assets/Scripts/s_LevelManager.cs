using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * @author Ryan Thorne,
 * levelmanager controls the state of the current level. this can be a parent class to the individual levels :>
 * 
 *
 */


public class s_LevelManager : MonoBehaviour {

	public AudioSource audio_source;
	// Use this for initialization
	void Start () {
		audio_source = GetComponent<AudioSource>();
		audio_source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
