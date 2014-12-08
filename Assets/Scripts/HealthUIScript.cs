using UnityEngine;
using System.Collections;

public class HealthUIScript : MonoBehaviour {
	public string text = "";
	public float test = 0;
	// Use this for initialization
	void Start () {
	
	}
	private string CalculateScore(float temp){
		//string text = "";
		if(temp <= 100 && temp >= 75){
			text = "HIGH";
		}else if(temp <= 74 && temp >= 50)
		{
			text = "MEDIUM";
		}else if(temp <= 49 && temp >= 25)
		{
			text = "LOW";
		}else if(temp <= 24 && temp > 0)
		{
			text = "CRITICAL";
		}

		return text;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find("Player");
		float tem = player.gameObject.GetComponent<PlayerHealthScript>().GetHealth();
		//float temp = hs.GetHealth();
		GetComponent<TextMesh> ().text = CalculateScore(tem);
		Debug.Log ("health" + tem);
	}
}
