using UnityEngine;
using System.Collections;

public class Limiter : MonoBehaviour
{
	private int limiter = 0;
	
	private static int limitAmount = 100;
	
	// Use this for initialization
	void Start()
	{
		StartCoroutine(ResetLimiter());
	}
	
	public bool NeedToLimit()
	{
		if(limiter >= limitAmount)
			return true;
		return false;
	}
	
	public void AddToLimit()
	{
		limiter++;
	}
	
	IEnumerator ResetLimiter()
	{
		yield return new WaitForSeconds(0.10f);
		limiter = 0;
		ResetLimiter();
	}
}
