using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (CharacterController))]
[AddComponentMenu("Control Script/FPSinput")]

public class FPSInput : MonoBehaviour {
	public float gravity = -9.8f;
	public float speed = 6.0f;
	private CharacterController _charController;
	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movenment = new Vector3 (deltaX, 0, deltaZ);
		movenment = Vector3.ClampMagnitude (movenment, speed);
		movenment.y = gravity;
		movenment *= Time.deltaTime;
		movenment = transform.TransformDirection (movenment);
		_charController.Move (movenment);
	}
}
