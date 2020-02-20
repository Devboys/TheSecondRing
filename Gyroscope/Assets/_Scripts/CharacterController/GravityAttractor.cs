using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {
	
	public float gravity = -9.8f;
	
	
	public void Attract(Rigidbody body, GravityBody.BodyType bodytype) {
		Vector3 gravityUp = -(body.position - transform.position).normalized;
		Vector3 localUp = body.transform.up;
		
		// Apply downwards gravity to body
		body.AddForce(gravityUp * gravity);
		switch (bodytype)
		{
			case GravityBody.BodyType.Player:
				body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;

				break;
			case GravityBody.BodyType.AllignedObject:
				break;
			case GravityBody.BodyType.FreeObject:
				break;
			default:
				break;
		}
	}
}
