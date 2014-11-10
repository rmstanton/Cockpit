using UnityEngine;
using System.Collections;

public class PlayerMovmentScript : MonoBehaviour
{
	
	public bool dontPassZero = true;
	
	private bool canChangeX = true;
	private bool canChangeY = true;
	private bool canChangeZ = true;
	private bool canChangeYaw = true;
	private bool canChangePitch = true;
	private bool canChangeRoll = true;
	
	private Vector3 angularVelocity = new Vector3(0,0,0);
	
	public float angularDampener = 60.0f;
	public float dampener = 60.0f;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
	}
	
	void FixedUpdate()
	{
		AdjustVelocity();
		AdjustRotation();
	}
	
	private void AdjustVelocity()
	{
		
		Vector3 newVel = this.rigidbody.velocity;
		
		//Debug.Log("Thrust is " + Input.GetAxis("Thrust"));
		//Debug.Log("YMovement is " + Input.GetAxis("YMovement"));
		
		//newVel.x += Input.GetAxis("Thrust") * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)/dampener;
		//newVel.z -= Input.GetAxis("Thrust") * Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)/dampener;
		//newVel.y += Input.GetAxis("Thrust") * Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)/dampener;
		newVel += Input.GetAxis("Thrust") * transform.TransformDirection(Vector3.forward)/dampener;
		newVel += Input.GetAxis("YMovement") * transform.TransformDirection(Vector3.up)/dampener;
		newVel += Input.GetAxis("Strafe") * transform.TransformDirection(Vector3.right)/dampener;
		//newVel.x -= Input.GetAxis("YMovement") * Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)/dampener;
		//newVel.y += Input.GetAxis("YMovement") * Mathf.Cos(transform.rotation.eulerAngles.x * Mathf.Deg2Rad) * Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)/dampener;
		//newVel.z += Input.GetAxis("YMovement") * Mathf.Sin(transform.rotation.eulerAngles.x * Mathf.Deg2Rad) * Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad)/dampener;
		
		if(newVel.x - rigidbody.velocity.x == 0)
			canChangeX = true;
		if(newVel.y - rigidbody.velocity.y == 0)
			canChangeY = true;
		if(newVel.z - rigidbody.velocity.z == 0)
			canChangeZ = true;
		
		if(dontPassZero)
		{
			if((this.rigidbody.velocity.x < 0 && newVel.x > 0) || (this.rigidbody.velocity.x > 0 && newVel.x < 0))
				canChangeX = false;
			if((this.rigidbody.velocity.y < 0 && newVel.y > 0) || (this.rigidbody.velocity.y > 0 && newVel.y < 0))
				canChangeY = false;
			if((this.rigidbody.velocity.z < 0 && newVel.z > 0) || (this.rigidbody.velocity.z > 0 && newVel.z < 0))
				canChangeZ = false;
		}
		
		if(!canChangeX)
			newVel.x = 0;
		if(!canChangeY)
			newVel.y = 0;
		if(!canChangeZ)
			newVel.z = 0;
		
		
		this.rigidbody.velocity = newVel;
	}
	
	private void AdjustRotation()
	{
		
		Vector3 newVel = angularVelocity;
		
		//Debug.Log("Roll is " + Input.GetAxis("Roll"));
		//Debug.Log("Yaw is " + Input.GetAxis("Yaw"));
		//Debug.Log("Pitch is " + Input.GetAxis("Pitch"));
		//Debug.Log("");
		
		newVel.x += Input.GetAxis("Pitch");
		newVel.y += Input.GetAxis("Yaw");
		newVel.z += Input.GetAxis("Roll");
		
		if(newVel.x - angularVelocity.x == 0)
			canChangePitch = true;
		if(newVel.y - angularVelocity.y == 0)
			canChangeYaw = true;
		if(newVel.z - angularVelocity.z == 0)
			canChangeRoll = true;
		
		if(dontPassZero)
		{
			if((angularVelocity.x < 0 && newVel.x > 0) || (angularVelocity.x > 0 && newVel.x < 0))
				canChangePitch = false;
			if((angularVelocity.y < 0 && newVel.y > 0) || (angularVelocity.y > 0 && newVel.y < 0))
				canChangeYaw = false;
			if((angularVelocity.z < 0 && newVel.z > 0) || (angularVelocity.z > 0 && newVel.z < 0))
				canChangeRoll = false;
		}
		if(!canChangePitch)
			newVel.x = 0;
		if(!canChangeYaw)
			newVel.y = 0;
		if(!canChangeRoll)
			newVel.z = 0;
		
		
		angularVelocity = newVel;
		
		transform.Rotate(newVel/angularDampener);
		
	}
}