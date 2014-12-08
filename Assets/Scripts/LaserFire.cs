using UnityEngine;
using System.Collections;

public class LaserFire : MonoBehaviour {
	ParticleSystem ps;
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Fire1") > 0) 
		{
						
			ps.enableEmission = true;		
				
		}
		else 
		{
			ps.enableEmission = false;
				
		}
	}
}
