using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get; private set; }
	public static InputSystem_Actions Inputs { get; private set; }

	void Awake()
	{
		Instance = this;
		Inputs = new InputSystem_Actions();
		SetPlayer();
	}

	public void SetPlayer()
	{
		Inputs.Disable();
		Inputs.Player.Enable();
	}
}
