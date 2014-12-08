using UnityEngine;
using System.Collections;

public class PlayerMineScript : MonoBehaviour {
	public int range;
	float start, useTime;
	bool ready;
	GameObject previous = null; 				//previous target
	float shipStores;

	// Use this for initialization
	void Start () {
		shipStores = 0;
		range = 5;
		start = Time.time;
		useTime = start + .5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Fire1") > 0) {
			shootBangs ();	
		} else {
			previous = null;
		}
	}

	void shootBangs(){
		GameObject thing;  					//currently targeted
		RaycastHit hit;
		int layer = LayerMask.NameToLayer ("Minable");
		int layerMask = 1 << layer;

		Ray pew = new Ray (transform.position, transform.TransformDirection (Vector3.forward));
		if (Physics.Raycast (pew, out hit, range, layerMask)) 
		{
			Debug.Log ("Mining a thing:" + hit.collider.transform.tag);
			thing = hit.collider.transform.gameObject;

			if (previous == null || thing != previous)
			{
				ready = false;
				previous = thing;
				delay(previous);

			} else if(ready){
				//increment storage
				//thing.reduce();

			}

		} 
		else{

			thing = null;
			ready = false;
		}


	}


	IEnumerator delay(GameObject prev){
		yield return new WaitForSeconds(0.5f);
		if (previous == prev){
			//prev = toDelay;
			ready = true;
		}



	}


}
