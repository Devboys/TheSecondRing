using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {
	
	GravityAttractor planet;
	Rigidbody _rigidbody;

    public float gravity = -9.8f;

	public BodyType bodyType = BodyType.FreeObject;
	public enum BodyType
	{
		Player, AllignedObject, FreeObject
	}

    [Tooltip("whether the rigidbody is attracted to the global attractor or not. \n(false = downwards gravity)")]
    public bool isAttracted;

	void Awake () {
		planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
		_rigidbody = GetComponent<Rigidbody> ();

		// Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
		_rigidbody.useGravity = false;
		switch (bodyType)
		{
			case BodyType.Player:
				_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
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
        if (isAttracted)
        {
            // Allow this body to be influenced by planet's gravity
            planet.Attract(_rigidbody, bodyType, gravity);
        }
        else
        {
            //apply regular gravity
            _rigidbody.AddForce(Vector3.up * gravity);
        }
	}
}