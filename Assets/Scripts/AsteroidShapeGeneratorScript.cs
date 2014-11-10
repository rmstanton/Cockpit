using UnityEngine;
using System.Collections;

public class AsteroidShapeGeneratorScript : MonoBehaviour
{
	public float generateReduction = 0.75f;
	private static int width = 30;
	private bool[,,] positioning = new bool[2*width+1, 2*width+1, 2*width+1];
	//int counter = 0;
	
	public GameObject chunk;
	
	private static int limiter = 0;
	private static float lastUpdate = 0;
	
	// Use this for initialization
	void Start()
	{
		if(generateReduction > 0.94)
			generateReduction = 0.94f;
		else if(generateReduction < 0)
			generateReduction = 0.0f;
		StartCoroutine(Generate(0, 0, 0, generateReduction));
		StartCoroutine(UpdateMass());
		StartCoroutine(ResetLimiter());
	}
	
	// Update is called once per frame
	void Update()
	{
		//if(counter++ % 100 == 0)
		//UpdateMass();
	}
	
	IEnumerator Generate(int x, int y, int z, float generateChance)
	{
		while(true)
		{
			if(limiter >= 100)
				yield return new WaitForSeconds(Random.Range(0.0f, 6.0f) * (generateReduction - generateChance));
			else
				break;
		}
		limiter++;
		if(x > width || x < -1*width || y > width || y < -1*width || z > width || z < -1*width)
		{
		}
		else if(HasChild(x, y, z))
		{
		}
		else
		{
			if(chunk == null)
				chunk = GameObject.Find("AsteroidChunk");
			GameObject child = Instantiate(chunk) as GameObject;
			child.transform.parent = this.transform;
			child.transform.localRotation = Quaternion.identity;
			child.transform.localPosition = new Vector3(x, y, z);
			
			SetChild(x, y, z, true);
			
			if(Random.Range(0.0f, 1.0f) < generateChance)
				StartCoroutine(Generate(x + 1, y, z, generateChance * generateReduction));
			//if(generateReduction > 0.8f)
			//yield return new WaitForSeconds(Random.Range(0.0f, 0.05f));
			if(Random.Range(0.0f, 1.0f) < generateChance)
				StartCoroutine(Generate(x - 1, y, z, generateChance * generateReduction));
			//if(generateReduction > 0.8f)
			//yield return new WaitForSeconds(Random.Range(0.0f, 0.05f));
			if(Random.Range(0.0f, 1.0f) < generateChance)
				StartCoroutine(Generate(x, y + 1, z, generateChance * generateReduction));
			//if(generateReduction > 0.8f)
			//yield return new WaitForSeconds(Random.Range(0.0f, 0.05f));
			if(Random.Range(0.0f, 1.0f) < generateChance)
				StartCoroutine(Generate(x, y - 1, z, generateChance * generateReduction));
			//if(generateReduction > 0.8f)
			//yield return new WaitForSeconds(Random.Range(0.0f, 0.05f));
			if(Random.Range(0.0f, 1.0f) < generateChance)
				StartCoroutine(Generate(x, y, z + 1, generateChance * generateReduction));
			//if(generateReduction > 0.8f)
			//yield return new WaitForSeconds(Random.Range(0.0f, 0.05f));
			if(Random.Range(0.0f, 1.0f) < generateChance)
				StartCoroutine(Generate(x, y, z - 1, generateChance * generateReduction));
		}
		yield return new WaitForSeconds(0);
	}
	
	bool HasChild(int x, int y, int z)
	{
		if(x > width || x < -1*width || y > width || y < -1*width || z > width || z < -1*width)
			return false;
		return positioning[x + width, y + width, z + width];
		/*
        foreach(Transform child in transform)
        {
            if(child.transform.position.x == x
            && child.transform.position.y == y
            && child.transform.position.z == z)
                return false;
        }
        return false;*/
	}
	
	void SetChild(int x, int y, int z, bool set)
	{
		positioning[x + width, y + width, z + width] = set;
	}
	
	IEnumerator UpdateMass()
	{
		yield return new WaitForSeconds(1.0f);
		int mass = 0;
		for(int i=0; i<2*width+1; i++)
			for(int j=0; j<2*width+1; j++)
				for(int k=0; k<2*width+1; k++)
					if(positioning[i, j, k])
						mass++;
		if(mass > 0)
			this.rigidbody.mass = mass;
		else
			this.rigidbody.mass = 1;
		StartCoroutine(UpdateMass());
	}
	
	IEnumerator ResetLimiter()
	{
		yield return new WaitForSeconds(0.10f);
		if(Time.time - lastUpdate > 0.1f)
		{
			limiter = 0;
			lastUpdate = Time.time;
		}
		ResetLimiter();
	}
}