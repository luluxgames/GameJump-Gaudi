using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float speed = 5f;
    public float acceleration = 10f;
    //public Animator meshAnim;

    [Header("RECOLLECTABLES")]
    public int flowersOnPosesion = 0;
    public GameObject flowerOnMouth;


    InputSystem_Actions inputs;
    bool isSprinting;
    Vector2 moveInput;
    Rigidbody rb;

    void Start()
    {
        inputs = InputManager.Inputs;
        rb = GetComponent<Rigidbody>();
        flowersOnPosesion = 0;
        flowerOnMouth.SetActive(false);
    }

    void Update()
    {
        moveInput = inputs.Player.Move.ReadValue<Vector2>();
        isSprinting = inputs.Player.Sprint.IsPressed();
    }

    void FixedUpdate()
    {
        Vector3 dir = (transform.up * moveInput.y + transform.right * moveInput.x).normalized;
        Vector3 movePos = rb.position + (dir * speed) * Time.fixedDeltaTime;

        bool canMove = true;

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            //meshAnim.SetFloat("speed", 1.0f); meshAnim.SetBool("sprint", isSprinting);
        }
        else
        {
            //meshAnim.SetFloat("speed", 0.0f); meshAnim.SetBool("sprint", false);
        }
        if (canMove)
            rb.MovePosition(Vector3.Lerp(rb.position, movePos, acceleration * Time.fixedDeltaTime));
    }
}
