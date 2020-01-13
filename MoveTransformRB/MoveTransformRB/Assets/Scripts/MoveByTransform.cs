using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simply move an object with rotating and moving the transform
/// </summary>
public class MoveByTransform : MonoBehaviour {

  [SerializeField]
  float rotationSpeed;

  [SerializeField]
  float movementSpeed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
    transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
	}
}
