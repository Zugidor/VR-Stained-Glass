/*
	@author: Michael Makarenko (Zugidor)
	@date: 19 March 2024
*/

using UnityEngine;

public class TeleportPlatform : MonoBehaviour
{
	// The CharacterController component (movement) of the XR Rig to teleport (move)
	public CharacterController rig;
	Renderer platform;
	Color ogColour;

	void Start()
	{
		// Get the renderer of the platform
		platform = GetComponent<Renderer>();
		// Store the original base map colour of the platform
		ogColour = platform.material.color;
	}

	private void TeleportXRRig()
	{
		// Teleport the Rig to this platform
		rig.Move(new Vector3(transform.position.x, rig.transform.position.y, transform.position.z) - rig.transform.position);
	}

	// OnPointer methods called by CardboardReticle

	public void OnPointerEnter()
	{
		// When the platform is looked at, change its color
		platform.material.color = Color.red;
	}

	public void OnPointerExit()
	{
		// When the platform is no longer looked at, change it back
		platform.material.color = ogColour;
	}

	public void OnPointerClick()
	{
		// When active platform is clicked, teleport the XR Rig
		TeleportXRRig();
	}
}