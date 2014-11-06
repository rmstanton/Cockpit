using UnityEngine;
using System.Collections;

public class PlayerMovmentScript : MonoBehaviour
{

    public bool dontPassZero = true;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        AdjustVelocity();
        AdjustRotation();
    }

    private void AdjustVelocity()
    {
        
        Vector3 newVel = this.rigidbody.velocity;

        Debug.Log("Thrust is " + Input.GetAxis("Thrust"));
        Debug.Log("YMovement is " + Input.GetAxis("YMovement"));

        newVel.x += Input.GetAxis("Thrust");
        newVel.y += Input.GetAxis("YMovement");
        
        if(dontPassZero)
        {
            if((this.rigidbody.velocity.x < 0 && newVel.x > 0) || (this.rigidbody.velocity.x > 0 && newVel.x < 0))
                newVel.x = 0;
            if((this.rigidbody.velocity.y < 0 && newVel.y > 0) || (this.rigidbody.velocity.y > 0 && newVel.y < 0))
                newVel.y = 0;
            if((this.rigidbody.velocity.z < 0 && newVel.z > 0) || (this.rigidbody.velocity.z > 0 && newVel.z < 0))
                newVel.z = 0;
        }

        
        this.rigidbody.velocity = newVel;
    }

    private void AdjustRotation()
    {
        
        Vector3 newVel = this.rigidbody.angularVelocity;
        
        Debug.Log("Roll is " + Input.GetAxis("Roll"));
        Debug.Log("Yaw is " + Input.GetAxis("Yaw"));
        Debug.Log("Pitch is " + Input.GetAxis("Pitch"));
        Debug.Log("");
        
        newVel.x += Input.GetAxis("Roll");
        newVel.y += Input.GetAxis("Yaw");
        newVel.z += Input.GetAxis("Pitch");
        
        if(dontPassZero)
        {
            if((this.rigidbody.angularVelocity.x < 0 && newVel.x > 0) || (this.rigidbody.angularVelocity.x > 0 && newVel.x < 0))
                newVel.x = 0;
            if((this.rigidbody.angularVelocity.y < 0 && newVel.y > 0) || (this.rigidbody.angularVelocity.y > 0 && newVel.y < 0))
                newVel.y = 0;
            if((this.rigidbody.angularVelocity.z < 0 && newVel.z > 0) || (this.rigidbody.angularVelocity.z > 0 && newVel.z < 0))
                newVel.z = 0;
        }
        
        
        this.rigidbody.angularVelocity = newVel;

    }
}
