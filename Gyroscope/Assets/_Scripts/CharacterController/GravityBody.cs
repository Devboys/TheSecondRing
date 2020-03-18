using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {
	
	GravityAttractor planet;
	Rigidbody rigidbody;
	public BodyType bodyType = BodyType.FreeObject;
	public enum BodyType
	{
		Player, AllignedObject, FreeObject
	}

	/*void Awake () {
	//	planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
		rigidbody = GetComponent<Rigidbody> ();

		// Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
		rigidbody.useGravity = false;
		switch (bodyType)
		{
			case BodyType.Player:
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
				break;
			case BodyType.AllignedObject:
				break;
			case BodyType.FreeObject:
				break;
			default:
				break;
		}
		
	}
	
	void FixedUpdate () {
		// Allow this body to be influenced by planet's gravity
		planet.Attract(rigidbody, bodyType);

		if (transform.position.magnitude > 200)
		{
			Destroy(this.gameObject);
		}
	}*/
}