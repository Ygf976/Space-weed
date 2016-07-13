using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {


	/// <summary>
	/// 1 - The speed of the ship and the target
	/// </summary>
	public Vector3 speed = new Vector3 (20, 20, 0);
	public GameObject target_object;

	// 2 - Store the movement and the component
	private Vector3 movement;
	private Rigidbody rigidbodyComponent;

	private float alpha;
	private float beta;


	
	// Update is called once per frame
	void Update () {

		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Vertical");
		float inputY = Input.GetAxis("Horizontal");

		// 4 - Movement per direction
		movement = new Vector3(
			speed.x * inputX,
			speed.y * inputY);

	}

	void FixedUpdate () {
		// 5 - Get the component and store the reference
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody>();
		// 6 - Rotate the game object
		//rigidbodyComponent.angularVelocity = movement;
		// 7 - Lock another the game object
		locateobject(target_object);
		Debug.Log (alpha);
		Debug.Log (beta);
		rigidbodyComponent.transform.rotation= Quaternion.Euler(new Vector3(beta,alpha));
	}

	void locateobject(GameObject target)
	{
		Vector3 pos = target.transform.position;
		float adj =target.transform.position.z - GetComponent<Rigidbody>().transform.position.z;
		float opp =target.transform.position.x - GetComponent<Rigidbody>().transform.position.x;
		float hyp =Mathf.Sqrt(Mathf.Pow(adj,2)+Mathf.Pow(opp,2));

		alpha = Mathf.Acos ((adj) / (hyp)) * 57.29f;
		beta = Mathf.Acos ((hyp) / (Mathf.Sqrt (Mathf.Pow (hyp, 2) +
			Mathf.Pow ((target.transform.position.y - GetComponent<Rigidbody> ().transform.position.y), 2))))
			*57.29f;
	}
}
