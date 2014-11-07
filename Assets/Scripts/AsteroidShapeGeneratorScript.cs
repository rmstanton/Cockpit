using UnityEngine;
using System.Collections;

public class AsteroidShapeGeneratorScript : MonoBehaviour
{
    public float generateReduction = 0.75f;

    // Use this for initialization
    void Start()
    {
        if(generateReduction > 0.75)
            generateReduction = 0.75f;
        Generate(0, 0, 0, 1.0f);
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    void Generate(int x, int y, int z, float generateChance)
    {
        Debug.Log("Generate Chance: " + generateChance);
        Debug.Log("Generate Reduct: " + generateReduction);
        Debug.Log("Combined Chance: " + generateChance * generateReduction);
        if(HasChild(x, y, z))
            return;
        GameObject chunk = GameObject.Find("AsteroidChunk");
        GameObject child = Instantiate(chunk) as GameObject;
        child.transform.parent = this.transform;
        child.transform.position = new Vector3(x, y, z);
        
        if(Random.Range(0.0f, 1.0f) < generateChance)
            Generate(x+1, y, z, generateChance * generateReduction);
        if(Random.Range(0.0f, 1.0f) < generateChance)
            Generate(x-1, y, z, generateChance * generateReduction);
        if(Random.Range(0.0f, 1.0f) < generateChance)
            Generate(x, y+1, z, generateChance * generateReduction);
        if(Random.Range(0.0f, 1.0f) < generateChance)
            Generate(x, y-1, z, generateChance * generateReduction);
        if(Random.Range(0.0f, 1.0f) < generateChance)
            Generate(x, y, z+1, generateChance * generateReduction);
        if(Random.Range(0.0f, 1.0f) < generateChance)
            Generate(x, y, z-1, generateChance * generateReduction);
    }

    bool HasChild(int x, int y, int z)
    {
        Debug.Log("In hasChild(" + x + "," + y + "," + z + ")");
        foreach(Transform child in transform)
        {
            if(child.transform.position.x == x
            && child.transform.position.y == y
            && child.transform.position.z == z)
                return false;
        }
        Debug.Log("returning false");
        return false;
    }
}
