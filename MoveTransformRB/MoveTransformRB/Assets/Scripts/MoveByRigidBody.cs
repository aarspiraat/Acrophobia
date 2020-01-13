using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move an object using its Rigid Body's methods
/// MovePosition and MoveRotation have the actual desired new location/rotation  as parameter
/// 
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class MoveByRigidBody : MonoBehaviour {

  [SerializeField]
  float rotationSpeed;

  [SerializeField]
  float movementSpeed;

  Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
    // transform the directin to be in local space and not global space
    Vector3 deltaPosition = transform.TransformDirection(new Vector3(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime));
		rigidbody.MovePosition(rigidbody.position + deltaPosition);
    
    // those damn quaternions!
    Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotationSpeed * Input.GetAxis("Horizontal"), 0) * Time.deltaTime);
    rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
	}
}
