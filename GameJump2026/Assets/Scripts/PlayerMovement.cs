using System.Collections;
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
	public LayerMask lostRoseLayers;
	public LayerMask roseLayers;

    float normalSpeed;
    Coroutine speedBoostCoroutine;

    InputSystem_Actions inputs;

	Vector2 moveInput;
	Vector3 moveDirection;

	void Start()
	{
		inputs = InputManager.Inputs;
		rb = GetComponent<Rigidbody>();
		flowersOnPosesion = 0;
		flowerOnMouth.SetActive(false);
        normalSpeed = speed;
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

	public void LoseRose()
	{
		if (flowerOnMouth.activeSelf)
			StartCoroutine(WaitForPickable());
		else
			StartCoroutine(Damage());
	}

	IEnumerator WaitForPickable()
	{
		SkinnedMeshRenderer[] meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer mesh in meshes)
		{
			foreach (Material mat in mesh.materials)
			{
				if (mat.HasProperty("_BaseColor"))
					mat.SetColor("_BaseColor", Color.red);
			}
		}
		GameObject rose = Instantiate(flowerPrefab, flowerOnMouth.transform.position, flowerOnMouth.transform.rotation);
		Collider roseCol = rose.GetComponent<Collider>();
		Collider roseColParent = rose.GetComponentInParent<Collider>();
		roseCol.enabled = false;
		roseCol.excludeLayers = lostRoseLayers;
		roseColParent.excludeLayers = lostRoseLayers;
		Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.2f, 1f), 0.0f).normalized;
		Rigidbody roseRb = rose.GetComponent<Rigidbody>();
		float force = 10.0f;
		roseRb.AddForce(randomDirection * force, ForceMode.Impulse);
		flowerOnMouth.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		roseCol.enabled = true;
		roseCol.excludeLayers = roseLayers;
		roseColParent.excludeLayers = roseLayers;
		foreach (SkinnedMeshRenderer mesh in meshes)
		{
			foreach (Material mat in mesh.materials)
			{
				if (mat.HasProperty("_BaseColor"))
					mat.SetColor("_BaseColor", Color.white);
			}
		}
	}

	IEnumerator Damage()
	{
		SkinnedMeshRenderer[] meshes = GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer mesh in meshes)
		{
			foreach (Material mat in mesh.materials)
			{
				if (mat.HasProperty("_BaseColor"))
					mat.SetColor("_BaseColor", Color.red);
			}
		}
		yield return new WaitForSeconds(0.5f);
		foreach (SkinnedMeshRenderer mesh in meshes)
		{
			foreach (Material mat in mesh.materials)
			{
				if (mat.HasProperty("_BaseColor"))
					mat.SetColor("_BaseColor", Color.white);
			}
		}
	}

    public void ActivateSpeedBoost(float multiplier, float duration)
    {
        if (speedBoostCoroutine != null)
            StopCoroutine(speedBoostCoroutine);
        speedBoostCoroutine = StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        speed = normalSpeed * multiplier;
        yield return new WaitForSeconds(duration);
        speed = normalSpeed;
        speedBoostCoroutine = null;
    }
}
