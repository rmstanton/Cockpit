using UnityEngine;
using System.Collections;

public class SandRoutput : MonoBehaviour {
	public Vector3 speed;
	public Vector3 rotation;
	/*void OnGUI(){
		GUI.TextArea(new Rect(10,Screen.height - 20,50,20),speed.ToString());
		GUI.TextArea(new Rect(10,Screen.height - 40,50,20),"Speed");
		GUI.TextArea (new Rect (10, Screen.height - 60, 50, 20), rotation.ToString());
		GUI.TextArea (new Rect (10, Screen.height - 80, 50, 20), "AngRot.");
	}*/
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//output = gameObject.GetComponent<SandRoutput> ();
		speed = this.rigidbody.velocity;
		rotation = this.rigidbody.angularVelocity;
	}
}
