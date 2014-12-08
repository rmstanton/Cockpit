using UnityEngine;
using System.Collections;

public class PlayerMineScript : MonoBehaviour {
	public int range;
	float start, useTime;
	bool ready;
	GameObject previous = null; 				//previous target
	float shipStores;
	int counter = 0;

	// Use this for initialization
	void Start () {
		shipStores = 0;
		range = 5;
		start = Time.time;
		useTime = start + .5f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
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
			Debug.Log ("Mining a thing:" + hit.collider.transform.tag +" counter: " + counter);
			//Debug.Log (previous == null ? "previous is null" : "previous not null");
			thing = hit.collider.transform.gameObject;

			if (previous == null || thing != previous)
			{
				//Debug.Log("previous is null || thing != previous - counter: " + counter);
				ready = false;
				previous = thing;
				StartCoroutine(delay(previous));

			} else if(ready){
				if (counter % 5 == 0)shipStores++;
				Debug.Log("Current stores:" + shipStores + " - counter: " + counter);
				//thing.reduce();

			}

		} 
		else{
			
			//Debug.Log("else - counter: " + counter);
			thing = null;
			ready = false;
		}
		counter++;


	}


	IEnumerator delay(GameObject prev){
		int persCounter = counter;
		//Debug.Log ("Delay init: " + persCounter);
		yield return new WaitForSeconds(0.5f);
		//Debug.Log ("Delay aft: " + persCounter);
		if (previous == prev){
			//Debug.Log ("Delay if: " + persCounter);
			//prev = toDelay;
			ready = true;
		}
	}
}
