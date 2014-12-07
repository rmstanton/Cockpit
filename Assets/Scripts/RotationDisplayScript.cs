using UnityEngine;
using System.Collections;

public class RotationDisplayScript : MonoBehaviour {
	
	public bool yaw = false;
	public bool pitch = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Quaternion newVect = this.transform.parent.transform.localRotation;
		
		if(!yaw) newVect.y = 0;
		if(!pitch) newVect.x = 0;
		if(yaw || pitch) newVect.z = 0;
		
		this.transform.localRotation = newVect;
		*/
		
		//this.rigidbody.angularVelocity = this.transform.parent.rigidbody.angularVelocity;
		
		//Vector3 newVect = this.transform.parent.transform.rotation.eulerAngles;
		//this.transform.localRotation.eulerAngles = newVect;
	
		Vector3 newVect = this.transform.parent.GetComponentInParent<PlayerMovmentScript>().angularVelocity/10.0f;
		
		if(!yaw) newVect.y = 0;
		if(!pitch) newVect.x = 0;
		if(yaw || pitch) newVect.z = 0;
		
		/*if(yaw)
		{
			newVect.x = 0;
			newVect.z = 0;
		}
		else if(pitch)
		{
			newVect.y = 0;
			newVect.z = 0;
		}
		else
		{
			newVect.x = 0;
			newVect.z = 0;
		}*/
		
		transform.Rotate(newVect);
	}
}
