using UnityEngine;

public class RoseTrigger : MonoBehaviour
{
	public bool isFlowerOnPossesion = false;
	AudioSource audSource;
	bool collected;
	PlayerMovement player;
	Rigidbody rb;
	Collider col;

	void Start()
	{
        if (isFlowerOnPossesion)
		{
            audSource = GetComponent<AudioSource>();
            audSource.Play();
            player = GetComponentInParent<PlayerMovement>();
			rb = GetComponent<Rigidbody>();
			col = GetComponent<Collider>();
            rb.useGravity = false;
			rb.isKinematic = true;
		}
	}

	void OnEnable()
	{
		collected = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (collected)
			return;
		if (isFlowerOnPossesion)
		{
			if (other.CompareTag("Pot"))
			{
				collected = true;
				player.flowersOnPosesion = 0;
				PotController pot = other.GetComponent<PotController>();
				pot.AddFlower();
				gameObject.SetActive(false);
			}
		}
		else
		{
			if (other.CompareTag("Head"))
			{
				player = other.GetComponent<PlayerMovement>();
				if (player == null)
                    player = other.GetComponentInParent<PlayerMovement>();
				if (!player.flowerOnMouth.activeSelf)
				{
					collected = true;
                    player.flowersOnPosesion++;
					player.flowerOnMouth.SetActive(true);
					Destroy(gameObject);
				}
			}
		}
	}
}
