using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {
	
	public float gravity = -9.8f;
	
    /// <summary>
    /// Attract Rigidbody with a custom gravity value
    /// </summary>
	public void Attract(Rigidbody body, GravityBody.BodyType bodytype, float customGravity) {
		Vector3 gravityUp = -(body.position - transform.position).normalized;
		Vector3 localUp = body.transform.up;
		
		// Apply downwards gravity to body
		body.AddForce(gravityUp * customGravity);
		switch (bodytype)
		{
			case GravityBody.BodyType.Player:
				body.GetComponent<Rigidbody>().MoveRotation(Quaternion.FromToRotation(localUp, gravityUp) * body.rotation);

				break;
			case GravityBody.BodyType.AllignedObject:
				break;
			case GravityBody.BodyType.FreeObject:
				break;
			default:
				break;
		}
	}

    /// <summary>
    /// Attract a Rigidbody with the gravity defined by the attractor
    /// </summary>
    public void Attract(Rigidbody body, GravityBody.BodyType bodytype)
    {
        Attract(body, bodytype, gravity);
    }
}
