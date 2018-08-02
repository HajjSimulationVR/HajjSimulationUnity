using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {
	
	public float walkSpeed;
	public float runSpeed;

	private Camera mainCamera;
	private CharacterController charachterController;

	private Vector3 moveDir;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		charachterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		float speed = Input.GetMouseButton(0)? runSpeed : walkSpeed;
		// always move along the camera forward as it is the direction that it being aimed at
		Vector3 desiredMove = mainCamera.transform.forward;

		// get a normal for the surface that is being touched to move along it
		RaycastHit hitInfo;
		Physics.SphereCast(transform.position, charachterController.radius, Vector3.down, out hitInfo,
			charachterController.height/2f, Physics.AllLayers, QueryTriggerInteraction.Ignore);
		desiredMove = Vector3.ProjectOnPlane(desiredMove, hitInfo.normal).normalized;

		moveDir.x = desiredMove.x*speed;
		moveDir.z = desiredMove.z*speed;


		if (charachterController.isGrounded)
		{
			moveDir.y = -10;
		}
		else
		{
			moveDir += Physics.gravity*Time.fixedDeltaTime;
		}

		charachterController.Move(moveDir*Time.fixedDeltaTime);
	}
}
