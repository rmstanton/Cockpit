using UnityEngine;
using System.Collections;

public class AsteroidShapeGeneratorScript : MonoBehaviour
{
    public float generateReduction = 0.75f;
    private bool[,,] positioning = new bool[101, 101, 101];

    // Use this for initialization
    void Start()
    {
        if(generateReduction > 0.95)
            generateReduction = 0.95f;
        else if(generateReduction < 0)
                generateReduction = 0.0f;
        StartCoroutine(Generate(0, 0, 0, generateReduction));
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator Generate(int x, int y, int z, float generateChance)
    {
        if(generateReduction>0.9f)
            yield return new WaitForSeconds( 10 * (generateReduction-0.9f) * generateReduction * Random.Range(0.0f, 1.0f) * (1-generateChance) * (1-generateChance));
        if(x > 50 || x < -50 || y > 50 || y < -50 || z > 50 || z < -50)
        {
        }
        else if(HasChild(x, y, z))
        {
        }
        else
        {
            GameObject chunk = GameObject.Find("AsteroidChunk");
            GameObject child = Instantiate(chunk) as GameObject;
            child.transform.parent = this.transform;
            child.transform.position = new Vector3(x, y, z);

            SetChild(x, y, z);
        
            if(Random.Range(0.0f, 1.0f) < generateChance)
                StartCoroutine(Generate(x + 1, y, z, generateChance * generateReduction));
            if(Random.Range(0.0f, 1.0f) < generateChance)
                StartCoroutine(Generate(x - 1, y, z, generateChance * generateReduction));
            if(Random.Range(0.0f, 1.0f) < generateChance)
                StartCoroutine(Generate(x, y + 1, z, generateChance * generateReduction));
            if(Random.Range(0.0f, 1.0f) < generateChance)
                StartCoroutine(Generate(x, y - 1, z, generateChance * generateReduction));
            if(Random.Range(0.0f, 1.0f) < generateChance)
                StartCoroutine(Generate(x, y, z + 1, generateChance * generateReduction));
            if(Random.Range(0.0f, 1.0f) < generateChance)
                StartCoroutine(Generate(x, y, z - 1, generateChance * generateReduction));
        }
    }

    bool HasChild(int x, int y, int z)
    {
        if(x > 50 || x < -50 || y > 50 || y < -50 || z > 50 || z < -50)
            return false;
        return positioning[x + 50, y + 50, z + 50];
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

    void SetChild(int x, int y, int z, bool set = true)
    {
        positioning[x + 50, y + 50, z + 50] = set;
    }
}
