using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public Vector3 speed = new Vector3(20, 20, 20);
	private Vector3 movement;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movement = new Vector3(Input.GetAxis("Horizontal") * speed.x,
		                       Input.GetAxis("Jump") * speed.z,
		                       Input.GetAxis ("Vertical") * speed.y);
	}



	void FixedUpdate(){
		rigidbody.velocity = movement;
	}
}
