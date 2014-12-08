using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	public int winCount;

	// Use this for initialization
	void Start () {
		winCount = 200;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		GameObject player = GameObject.Find("Player");
		PlayerMineScript mining = player.GetComponent<PlayerMineScript> ();
		if (mining.shipStores > winCount) {
						Application.LoadLevel ("SimpleWin");
		} else {
			Debug.Log("More Resources needed");
		}

	}
}
