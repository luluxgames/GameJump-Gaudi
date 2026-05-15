using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public static InputSystem_Actions Inputs { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Inputs = new InputSystem_Actions();
        }
        else
            Destroy(gameObject);
        SetPlayer();
    }

    public void SetPlayer()
    {
        Inputs.Disable();
        Inputs.Player.Enable();
    }
}
