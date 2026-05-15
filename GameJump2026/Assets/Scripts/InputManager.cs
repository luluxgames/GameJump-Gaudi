using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get; private set; }
	public static InputSystem_Actions Inputs { get; private set; }

	void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
        DontDestroyOnLoad(gameObject);
        Inputs = new InputSystem_Actions();
		SetPlayer();
	}

	public void SetPlayer()
	{
		Inputs.Disable();
		Inputs.Player.Enable();
	}
}
