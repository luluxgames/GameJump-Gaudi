using UnityEngine;

public class Fireball : MonoBehaviour
{
	public float speed = 2.0f;

	void Start()
	{
		Destroy(gameObject, 25.0f);
	}

	void Update()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerMovement player = other.GetComponent<PlayerMovement>();
			player.LoseRose();
			Destroy(gameObject);
		}
	}
}
