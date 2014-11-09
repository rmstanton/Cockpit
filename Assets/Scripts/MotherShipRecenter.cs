using UnityEngine;
using System.Collections;

public class MotherShipRecenter : MonoBehaviour {

    public bool randomHit = false;
	// Use this for initialization
	void Start () {
	
	}
	void FixedUpdate () {
        if(randomHit)
        {
            this.rigidbody.velocity = new Vector3(Random.Range(0.0f, 10f),Random.Range(0.0f, 10f),Random.Range(0.0f, 10f));
            this.rigidbody.angularVelocity = new Vector3(Random.Range(0.0f, 10f),Random.Range(0.0f, 10f),Random.Range(0.0f, 10f));
            randomHit = false;
        }
        
        if(this.transform.position != new Vector3(0, 0, 0))
        {
            this.transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, 0.1f);
        }
        
        if(this.transform.eulerAngles != new Vector3(0, 0, 0))
        {
            this.transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, Vector3.zero, 1f);
        }

        /*
        if(this.rigidbody.velocity != new Vector3(0,0,0) || !allGood)
        {
            Debug.Log("Not Centered");
            Debug.Log("allGood " + allGood);
            Debug.Log("needToStop " + needToStop);
            Debug.Log("needToStraighten " + needToStraighten);
            Debug.Log("needToSpin " + needToSpin);
            if(allGood)
            {
                needToStop = true;
                needToStraighten = true;
                needToSpin = true;
                allGood = false;
            }
            if(needToStop)
            {
                this.rigidbody.angularDrag = 2;
                Debug.Log("in needToStop");
                Vector3 newVel = this.rigidbody.velocity;
                newVel *= dampeningSpeed;
                Vector3 newRot = this.rigidbody.angularVelocity;
                newRot *= dampeningSpeed;
                if(Mathf.Abs(newVel.x) < 0.5) newVel.x = 0;
                if(Mathf.Abs(newVel.y) < 0.5) newVel.y = 0;
                if(Mathf.Abs(newVel.z) < 0.5) newVel.z = 0;
                if(Mathf.Abs(newRot.x) < 0.5) newRot.x = 0;
                if(Mathf.Abs(newRot.y) < 0.5) newRot.y = 0;
                if(Mathf.Abs(newRot.z) < 0.5) newRot.z = 0;
                if(newVel.x == 0
                   && newVel.y == 0
                   && newVel.z == 0
                   && newRot.x == 0
                   && newRot.y == 0
                   && newRot.z == 0)
                    needToStop = false;
                this.rigidbody.velocity = newVel;
                if(needToStop)
                    this.rigidbody.angularVelocity = newRot;
                else
                    this.rigidbody.angularVelocity = new Vector3(0,0,0);
            }
            else
            {

                if(needToStraighten)
                {
                    Debug.Log("in needToStraighten");
                    Vector3 newRot = new Vector3(0,0,0);
                    if(this.transform.rotation.eulerAngles.x > 1 && this.transform.rotation.eulerAngles.x < 180)
                        newRot.x = -1;
                    else if(this.transform.rotation.eulerAngles.x < -1 || this.transform.rotation.eulerAngles.x >= 180)
                        newRot.x = 1;
                    else if(this.transform.rotation.eulerAngles.y > 1)
                        newRot.y = -1;
                    else if(this.transform.rotation.eulerAngles.y < -1)
                        newRot.y = 1;
                    else if(this.transform.rotation.eulerAngles.z > 1)
                        newRot.z = -1;
                    else if(this.transform.rotation.eulerAngles.z < -1)
                        newRot.z = 1;
                    Vector3 newAng = this.transform.rotation.eulerAngles;
                    if(newRot.x == 0)
                    {
                        newAng.x = 0;
                        if(newRot.y == 0)
                        {
                            newAng.y = 0;
                            if(newRot.z == 0)
                                newAng.z = 0;
                        }
                    }
                    this.transform.eulerAngles = newAng;
                    this.transform.Rotate(newRot);
                    Debug.Log("newRot " + newRot);
                    Debug.Log("newAng " + newAng);
                    if(newRot.x == 0
                       && newRot.y == 0
                       && newRot.z == 0)
                        needToStraighten = false;
                }
                else
                {
                    Debug.Log("in needToReturn");
                    Vector3 newVel = new Vector3(0,0,0);
                    if(this.transform.position.x > velThreshold)
                        newVel.x = -1*velThreshold;
                    else if(this.transform.position.x < -1*velThreshold)
                        newVel.x = velThreshold;
                    if(this.transform.position.y > velThreshold)
                        newVel.y = -1*velThreshold;
                    else if(this.transform.position.x < -1*velThreshold)
                        newVel.y = velThreshold;
                    if(this.transform.position.z > velThreshold)
                        newVel.z = -1*velThreshold;
                    else if(this.transform.position.z < -1*velThreshold)
                        newVel.z = velThreshold;
                    Vector3 newPos = this.transform.position;
                    if(newVel.x == 0)
                        newPos.x = 0;
                    if(newVel.y == 0)
                        newPos.y = 0;
                    if(newVel.z == 0)
                        newPos.z = 0;
                    this.rigidbody.velocity = newVel;
                    this.transform.position = newPos;
                    if(newVel.x == 0
                       && newVel.y == 0
                       && newVel.z == 0)
                        allGood = true;
                }
            }
         
        }
        else if(needToSpin)
        {
            this.rigidbody.velocity = new Vector3(0,0,0);
            needToSpin = false;
               
        }*/
        //else
            //this.transform.Rotate(new Vector3(0,0.5f,0));
	
	}
}
