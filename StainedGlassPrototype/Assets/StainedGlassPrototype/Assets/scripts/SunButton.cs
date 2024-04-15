/*
	@author: Michael Makarenko (Zugidor)
	@date: 20 March 2024
*/

using UnityEngine;

public class SunButton : MonoBehaviour
{
	// The Sun directional light to rotate (about y-axis only, continuously until pressed again)
	public GameObject sun;
	Animator sunAnim;
	Renderer button;
	Color ogColour;
	bool pressed = false;

	void Start()
	{
		// Get the renderer of the button
		button = GetComponent<Renderer>();
		// Store the original base map colour of the button
		ogColour = button.material.color;
		// Get the animator of the sun
		sunAnim = sun.GetComponent<Animator>();
	}

	// OnPointer methods called by CardboardReticle

	public void OnPointerEnter()
	{
		// Change the button's colour to indicate it's being looked at
		button.material.color = Color.red;
	}

	public void OnPointerExit()
	{
		// Change the button's colour back to its original colour
		button.material.color = ogColour;
		// Reset pressed to false
		pressed = false;
	}

	public void OnPointerClick()
	{
		// If the button is pressed, toggle animation
		if (!pressed)
		{
			sunAnim.SetTrigger("SunButtonPress");
			pressed = true;
		}
	}
}