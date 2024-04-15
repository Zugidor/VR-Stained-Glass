/*
	@author: Michael Makarenko (Zugidor)
	@date: 15 March 2024
*/

using UnityEngine;

// RequireComponent automatically adds a CharacterController as a dependency.
[RequireComponent(typeof(CharacterController))]

public class CamController : MonoBehaviour
{
	// members
	CharacterController charCon;
	public float speed = 1.5f;
	float pitch, yaw, roll;
	Vector3 MovementInput()
	{
		Vector3 direction = Vector3.zero;
		Vector3 forward = transform.forward;
		Vector3 right = transform.right;
		if (Input.GetKey(KeyCode.W))
		{
			direction += forward;
		}
		if (Input.GetKey(KeyCode.S))
		{
			direction -= forward;
		}
		if (Input.GetKey(KeyCode.A))
		{
			direction -= right;
		}
		if (Input.GetKey(KeyCode.D))
		{
			direction += right;
		}
		direction.y = 0;
		return direction;
	}
	// Unity lifecycle functions
	void Start()
	{
		charCon = GetComponent<CharacterController>();
		pitch = transform.eulerAngles.x;
		yaw = transform.eulerAngles.y;
		roll = transform.eulerAngles.z;
	}
	void Update()
	{
		// Press Escape to quit
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		}

		Vector3 moveDirection = speed * MovementInput();

		// Press Shift to sprint
		if (Input.GetKey(KeyCode.LeftShift))
		{
			moveDirection *= 2;
		}

		charCon.Move(moveDirection * Time.deltaTime);

		// Character view rotation with right mouse click
		if (Input.GetMouseButton(1))
		{
			// Hide and lock cursor when right mouse clicked
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			// Rotation
			Vector2 mouseMovement = 20 * Time.deltaTime * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
			yaw += mouseMovement.x;
			pitch += mouseMovement.y;
			transform.eulerAngles = new Vector3(pitch, yaw, roll);
		}
		else
		{
			// Unlock and show cursor when right mouse click released
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}