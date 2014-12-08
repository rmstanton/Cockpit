using UnityEngine;
using System.Collections;

public class chunkHealth : MonoBehaviour {
	int Durability;
	GameObject ship;
	int health;
	// Use this for initialization
	void Start () {
		health = 100;
		ship = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
