using UnityEngine;
using System.Collections;

public class SpawnAsteroids : MonoBehaviour {
	//Vector3 speed = new Vector3(20,20,20);
	//public Transform asteroid;
	public int aCount = 20;
	public float range = 20;
	public GameObject roidsOrig;
	public int spawnDistance;
	public int avgSpawnsPerSecond = 10;
	public const int FRAMES = 60;
	public int moverSpawnRange = 250;
	public int moverMaxSpeed = 100;
	public float initRotation;




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



			roids.transform.Rotate(new Vector3(
				Random.Range (-90, 90),
				Random.Range (-90, 90),
				Random.Range (-90, 90)
				));


			/*roids.transform.GetComponent<AsteroidMove>().rotate = new Vector3(Random.Range (-initRotation, initRotation),
			                                                                  Random.Range (-initRotation, initRotation),
			                                                                  Random.Range (-initRotation, initRotation));*/

			roids.rigidbody.angularVelocity = new Vector3(Random.Range (-initRotation/2, initRotation/2) + Random.Range (-initRotation/2, initRotation/2),
			                                              Random.Range (-initRotation/2, initRotation/2) + Random.Range (-initRotation/2, initRotation/2),
			                                              Random.Range (-initRotation/2, initRotation/2) + Random.Range (-initRotation/2, initRotation/2));
		}
	}
	
	// Update is called once per frame
	void Update () {


		if (Random.Range (1, avgSpawnsPerSecond * FRAMES) == 1 /*!testSpawn*/) {
			int spawnCase = Random.Range (1, 6);
			GameObject roid = Instantiate (roidsOrig) as GameObject;
			roid.GetComponent<AsteroidShapeGeneratorScript>().generateReduction = Random.Range(0.05f,0.5f);

			switch (spawnCase){
			case 1:
				roid.transform.position = new Vector3 (moverSpawnRange, 
				                                       Random.Range (-moverSpawnRange, moverSpawnRange),
				                                       Random.Range (-moverSpawnRange, moverSpawnRange));
				break;
			
			case 2:
				roid.transform.position = new Vector3 (-moverSpawnRange, 
				                                       Random.Range (-moverSpawnRange, moverSpawnRange),
				                                       Random.Range (-moverSpawnRange, moverSpawnRange));
				break;
			case 3:
				roid.transform.position = new Vector3 (Random.Range (-moverSpawnRange, moverSpawnRange), 
				                                       moverSpawnRange,
				                                       Random.Range (-moverSpawnRange, moverSpawnRange));
				break;
			case 4:
				roid.transform.position = new Vector3 (Random.Range (-moverSpawnRange, moverSpawnRange), 
				                                       -moverSpawnRange,
				                                       Random.Range (-moverSpawnRange, moverSpawnRange));
				break;
			case 5:
				roid.transform.position = new Vector3 (Random.Range (-moverSpawnRange, moverSpawnRange), 
				                                       Random.Range (-moverSpawnRange, moverSpawnRange),
				                                       moverSpawnRange);
				break;

			case 6:
				roid.transform.position = new Vector3 (Random.Range (-moverSpawnRange, moverSpawnRange), 
				                                       Random.Range (-moverSpawnRange, moverSpawnRange),
				                                       -moverSpawnRange);
				break;
			default:
				Debug.Log ("Spawn Update default case ");
				roid.transform.position = new Vector3 (Random.Range (-moverSpawnRange, moverSpawnRange), 
				                                       Random.Range (-moverSpawnRange, moverSpawnRange),
				                                       Random.Range (-moverSpawnRange, moverSpawnRange));
				break;
			}



			roid.rigidbody.velocity = new Vector3(Random.Range (-moverMaxSpeed, moverMaxSpeed),
			                                      Random.Range (-moverMaxSpeed, moverMaxSpeed),
			                                      Random.Range (-moverMaxSpeed, moverMaxSpeed));
		}



			
	}
}

