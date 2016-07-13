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
		rigidbodyComponent.transform.rotation= Quaternion.Euler(new Vector3(alpha,beta));
		//

	}

	void locateobject(GameObject target)
	{
		Vector3 pos = target.transform.position;
		float z =target.transform.position.z - transform.position.z;
		float y =target.transform.position.y - transform.position.y;
		float x =target.transform.position.x - transform.position.x;
		alpha = Mathf.Atan (y / z)*Mathf.Rad2Deg;
		beta = Mathf.Atan (z / x)*Mathf.Rad2Deg;


		//float hyp =Mathf.Sqrt(Mathf.Pow(adj,2)+Mathf.Pow(opp,2));

		/*alpha =Mathf.Sign((adj) / (hyp))* Mathf.Acos ((adj) / (hyp)) * 57.29f;
		beta =Mathf.Sign((hyp) / (Mathf.Sqrt (Mathf.Pow (hyp, 2) +
			Mathf.Pow ((target.transform.position.y - transform.position.y), 2))))
			* Mathf.Acos ((hyp) / (Mathf.Sqrt (Mathf.Pow (hyp, 2) +
			Mathf.Pow ((target.transform.position.y - transform.position.y), 2))))
			*Mathf.Rad2Deg;
		*/


	}
}
