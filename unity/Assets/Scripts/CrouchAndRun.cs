using UnityEngine;
using System.Collections;
 
public class CrouchAndRun : MonoBehaviour 
{
    public float walkSpeed = 10; // regular speed
    public float crchSpeed = 3; // crouching speed
    public float runSpeed = 15; // run speed
	public float speed; 
 
    private CharacterMotor chMotor;
    private Transform tr;
    private float dist; // distance to ground
	
	private bool canRun = true;
	private bool isRunning = false;
	public float runTime = 5f;
	public float runCoolDownTime = 5f;
 
    // Use this for initialization
    void Start () 
    {
		speed = walkSpeed;
        chMotor =  GetComponent<CharacterMotor>();
        tr = transform;
        CharacterController ch = GetComponent<CharacterController>();
        dist = ch.height/2; // calculate distance to ground
    }
 
    // Update is called once per frame
    void FixedUpdate ()
    {
	   	// setting up max sprint time and cool down update
		if (isRunning && (Input.GetKey ("w") || Input.GetKey ("a") || Input.GetKey ("d") || Input.GetKey ("s") )) {
			Debug.Log ("running");
			runTime -= Time.deltaTime;
			if(runTime <= 0) {
				Debug.Log ("start walking");
				isRunning =false;
				canRun = false;
			}
		} else {
			runTime += Time.deltaTime;
			if(runTime > 5f) {
				runTime = 5f;
			}
		}
		
		
		if(!canRun && !isRunning && !Input.GetKey ("left shift")) {
			Debug.Log ( "Not running time to cool down");
			runCoolDownTime -= Time.deltaTime;
			Debug.Log (runCoolDownTime);
			if(runCoolDownTime <= 0 ) {
				canRun = true;
				runCoolDownTime = 5f;
				runTime = 5f;
			}
		}
       	
		float vScale = 2.5f;
        
 		speed = walkSpeed;
        if ((Input.GetKey("left shift") || Input.GetKey("right shift")) && chMotor.grounded)
        {
            if(canRun) {
				speed = runSpeed;
				isRunning = true;
			} else {
				
			}
        }
		
		if (Input.GetKeyUp("left shift") || Input.GetKeyUp("right shift")) {
			isRunning = false;
			speed = walkSpeed;
		}
 
        if (Input.GetKey("c"))
        { // press C to crouch
            vScale = 1.0f;
            speed = crchSpeed; // slow down when crouching
        }
 
        chMotor.movement.maxForwardSpeed = speed; // set max speed
        float ultScale = tr.localScale.y; // crouch/stand up smoothly 
 
       Vector3 tmpScale = tr.localScale;
       Vector3 tmpPosition = tr.position;
 
       tmpScale.y = Mathf.Lerp(tr.localScale.y, vScale, 5 * Time.deltaTime);
       tr.localScale = tmpScale;
 
       tmpPosition.y += dist * (tr.localScale.y - ultScale); // fix vertical position       
       tr.position = tmpPosition;
    }
	
	
}