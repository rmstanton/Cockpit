using UnityEngine;
using System.Collections;

public class AsteroidMove : MonoBehaviour {
	public Vector3 move;
	public Vector3 rotate = new Vector3(0,0,0);
	public GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		/*if (rotate != null)
			transform.Rotate (rotate);*/

		if (Vector3.Distance (this.transform.position, Player.transform.position) > 500) {
			Destroy(this.gameObject);		
		}
	}
}
