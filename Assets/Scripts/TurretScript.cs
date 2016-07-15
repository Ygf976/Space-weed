using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {


	
	public GameObject target_object;
    private Vector3 targetDirection;

    public Rigidbody RB; //the turret RigidBody

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

	void Update () {

	}

	void FixedUpdate () {

        targetDirection = target_object.transform.position - RB.transform.position;
        
		RB.transform.rotation= Quaternion.LookRotation(targetDirection);	//rotate in direction of the target

	}
}
