using UnityEngine;
using System.Collections;

public class PlayerMovmentScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		Vector3 newVel = this.rigidbody.velocity;
		int xvel = 0, yvel = 0, zvel = 0;
		if(this.rigidbody.velocity.x > 0)
			xvel = 1;
		if(this.rigidbody.velocity.x < 0)
			xvel = -1;
		
		if(this.rigidbody.velocity.y > 0)
			yvel = 1;
		if(this.rigidbody.velocity.y < 0)
			yvel = -1;
		
		if(this.rigidbody.velocity.z > 0)
			zvel = 1;
		if(this.rigidbody.velocity.z < 0)
			zvel = -1;

	}
}
