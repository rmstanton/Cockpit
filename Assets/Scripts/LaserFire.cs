using UnityEngine;
using System.Collections;

public class LaserFire : MonoBehaviour {
	ParticleSystem ps;
	public AudioSource asrc;
	public AudioClip rep;
	public AudioClip end;
	bool active = false;
	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Fire1") > 0) 
		{
					
			ps.enableEmission = true;	
			if(!active)
			{
				asrc.loop = true;
				asrc.clip = rep;
				active = true;
				asrc.Play();
			}
				
		}
		else 
		{
			ps.enableEmission = false;
			if(active)
			{
				asrc.loop = false;
				asrc.clip = end;
				asrc.Play();
				active = false;
			}
				
		}
	}
}
