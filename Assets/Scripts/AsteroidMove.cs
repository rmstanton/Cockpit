using UnityEngine;
using System.Collections;

public class AsteroidMove : MonoBehaviour {
	public Vector3 move;
	public Vector3 rotate = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate != null)
			transform.Rotate (rotate);
	}
}
