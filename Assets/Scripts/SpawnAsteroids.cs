using UnityEngine;
using System.Collections;

public class SpawnAsteroids : MonoBehaviour {
	//Vector3 speed = new Vector3(20,20,20);
	//public Transform asteroid;
	public int aCount = 20;
	public float range = 20;
	public GameObject roids;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < aCount; i++) {
			//roids = Instantiate(Resources.Load ("Asteroid")) as GameObject;
			roids = (GameObject) Instantiate(roids);
			roids.transform.parent = this.transform;
			roids.transform.position = new Vector3(
				Random.Range (-range, range),
				Random.Range (-range, range),
				Random.Range (-range, range) );

			roids.transform.Rotate(new Vector3(
				Random.Range (-180, 180),
				Random.Range (-180, 180),
				Random.Range (-180, 180)
				));

			roids.transform.GetComponent<AsteroidMove>().rotate = new Vector3(Random.Range (-5, 5),
			                                                                  Random.Range (-5, 5),
			                                                                  Random.Range (-5, 5));
		}
	}
	
	// Update is called once per frame
	void Update () {
			
			
			
	}
}

