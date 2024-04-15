/*
	@author: Michael Makarenko (Zugidor)
	@date: 20 March 2024
*/

using UnityEngine;

public class ElevateButton : MonoBehaviour
{
	// The CharacterController component (movement) of the XR Rig to elevate (move)
	public CharacterController rig;
	// The parent of the ground object(s) to elevate (parent doesn't move, only children)
	public GameObject elevatorParent;
	bool grounded = true;
	bool pressed = false;
	Renderer button;
	Color ogColour;
	float rigElevatedY, rigGroundedY, elevatorElevatedY, elevatorGroundedY;

	void Start()
	{
		// Get the renderer of the button
		button = GetComponent<Renderer>();
		// Store the original base map colour of the button
		ogColour = button.material.color;
		// Store the original position of the XR Rig as grounded position
		rigGroundedY = rig.transform.position.y;
		// New position for the XR Rig (elevated)
		rigElevatedY = rigGroundedY + 0.8f;
		// Store the original Y of the elevator's children as grounded Y (assuming all children are level)
		elevatorGroundedY = elevatorParent.transform.GetChild(0).position.y;
		// New Y for the elevator's children (elevated, again assuming all children are level)
		elevatorElevatedY = elevatorGroundedY + 0.8f;
	}

	private void Elevate()
	{
		// Elevate the Rig
		rig.Move(new Vector3(rig.transform.position.x, rigElevatedY, rig.transform.position.z) - rig.transform.position);
		// Elevate the elevator's children
		for (int i = 0; i < elevatorParent.transform.childCount; i++)
		{
			elevatorParent.transform.GetChild(i).position = new Vector3(elevatorParent.transform.GetChild(i).position.x, elevatorElevatedY, elevatorParent.transform.GetChild(i).position.z);
		}
		// Set grounded to false
		grounded = false;
	}

	private void Ground()
	{
		// Ground the elevator's children
		for (int i = 0; i < elevatorParent.transform.childCount; i++)
		{
			elevatorParent.transform.GetChild(i).position = new Vector3(elevatorParent.transform.GetChild(i).position.x, elevatorGroundedY, elevatorParent.transform.GetChild(i).position.z);
			// Disable the BoxCollider of the elevator's children to prevent the XR Rig from getting stuck
			elevatorParent.transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
		}
		// Ground the Rig 
		rig.Move(new Vector3(rig.transform.position.x, rigGroundedY, rig.transform.position.z) - rig.transform.position);
		// Set grounded to true
		grounded = true;
		// Re-enable the BoxCollider of the elevator's children
		for (int i = 0; i < elevatorParent.transform.childCount; i++)
		{
			elevatorParent.transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
		}
	}

	// OnPointer methods called by CardboardReticle

	public void OnPointerEnter()
	{
		// When the button is looked at, change its color
		button.material.color = Color.red;
	}

	public void OnPointerExit()
	{
		// When the button is no longer looked at, change it back
		button.material.color = ogColour;
		// Set pressed to false only after looking away, preventing pressed button from spam activating
		pressed = false;
	}

	public void OnPointerClick()
	{
		if (!pressed)
		{
			// When unpressed button is clicked, elevate or ground the XR Rig and elevator's children
			if (grounded)
			{
				Elevate();
			}
			else
			{
				Ground();
			}
			// Sync the other button's grounded state with this button's grounded state
			transform.parent.GetChild((transform.GetSiblingIndex() + 1) % 2).GetComponent<ElevateButton>().grounded = grounded;
			// Set pressed to true to prevent spam activating
			pressed = true;
		}
	}
}