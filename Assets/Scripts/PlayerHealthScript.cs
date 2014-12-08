using UnityEngine;
using System.Collections;

public class PlayerHealthScript : MonoBehaviour {
	public float Health = 100;
	public int magnitudeThreshold;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			// Death stuff	: 
			Application.LoadLevel("Death")	;
		}
	}

	void OnCollisionEnter(Collision c){
		/*foreach(ContactPoint point in c.contacts){

		}*/
		float mag = c.relativeVelocity.magnitude;
		Debug.Log ("Relative velocity: " + mag);
		if ( mag > magnitudeThreshold) {
			Health -= mag * 2;
			Debug.Log("Health: " + Health);
		}

	}
}
