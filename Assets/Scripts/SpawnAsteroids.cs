using UnityEngine;
using System.Collections;

public class SpawnAsteroids : MonoBehaviour {
	//Vector3 speed = new Vector3(20,20,20);
	//public Transform asteroid;
	public int aCount = 20;
	public float range = 20;
	public GameObject roidsOrig;
	public int spawnDistance;
	public const int FRAMES = 60;
	public float initRotation;
	public bool testTargeted = false, testSent = false;
	public Vector3 testDest;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < aCount; i++) {
			GameObject roids = Instantiate(roidsOrig) as GameObject;
			roids.GetComponent<AsteroidShapeGeneratorScript>().generateReduction = Random.Range(0.5f,0.9f);

			roids.transform.parent = this.transform;
			roids.transform.position = new Vector3(
				Random.Range (-range, range),
				Random.Range (-range, range),
				Random.Range (-range, range) );

			if (!testTargeted){
				testDest = roids.transform.position;
				testTargeted = true;
			}

			roids.transform.Rotate(new Vector3(
				Random.Range (-90, 90),
				Random.Range (-90, 90),
				Random.Range (-90, 90)
				));


			/*roids.transform.GetComponent<AsteroidMove>().rotate = new Vector3(Random.Range (-initRotation, initRotation),
			                                                                  Random.Range (-initRotation, initRotation),
			                                                                  Random.Range (-initRotation, initRotation));*/

			roids.rigidbody.angularVelocity = new Vector3(Random.Range (-initRotation, initRotation),
			                                              Random.Range (-initRotation, initRotation),
			                                              Random.Range (-initRotation, initRotation));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (1, 10 * FRAMES) == 1 /*!testSpawn*/) {
			GameObject roid = Instantiate (roidsOrig) as GameObject;
			roid.transform.position = new Vector3(
				Random.Range (-range, range),
				Random.Range (-range, range),
				Random.Range (-range, range) );

			roid.rigidbody.velocity = new Vector3(Random.Range (-100, 100),
			                                      Random.Range (-100, 100),
			                                      Random.Range (-100, 100));
		}

		/*if (!testSent) {
			GameObject testRoid = Instantiate(roidsOrig) as GameObject;
			testRoid.transform.position = new Vector3 (20, 20, 20);

		}*/

			
	}
}

