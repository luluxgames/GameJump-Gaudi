using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("MOVEMENT")]
	public float speed = 5f;
	public float rotSpeed = 10f;
	public Rigidbody rb;
	public Animator meshAnim;
	public Transform visual;

	[Header("RECOLLECTABLES")]
	public int flowersOnPosesion = 0;
	public GameObject flowerOnMouth;
	public GameObject flowerPrefab;

	InputSystem_Actions inputs;

	Vector2 moveInput;
	Vector3 moveDirection;

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
		moveDirection = new Vector3(moveInput.x, moveInput.y, 0f).normalized;
		meshAnim.SetFloat("speed", moveDirection.magnitude);
	}

	void FixedUpdate()
	{
		Vector3 velocity = moveDirection * speed;
		velocity.z = rb.linearVelocity.z;
		rb.linearVelocity = velocity;
		if (moveDirection.sqrMagnitude <= 0.001f)
			return;
		float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
		visual.rotation = Quaternion.Slerp(visual.rotation, targetRotation, rotSpeed * Time.fixedDeltaTime);
	}

	public void SpawnRose()
	{
		if (flowerOnMouth.activeSelf)
		{
            GameObject rose = Instantiate(flowerPrefab, flowerOnMouth.transform.position, flowerOnMouth.transform.rotation);
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.2f, 1f), 0.0f).normalized;
            Rigidbody roseRb = rose.GetComponent<Rigidbody>();
            float force = 8f;
            roseRb.AddForce(randomDirection * force, ForceMode.Impulse);
            flowerOnMouth.SetActive(false);
        }
    }
}
