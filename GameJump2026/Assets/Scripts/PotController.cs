using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
	public List<GameObject> flowers;

	public void AddFlower()
	{
		flowers[0].SetActive(true);
		flowers.RemoveAt(0);
		GameManager.Instance.flowersCollected++;
		CheckFlowers();
	}
	void CheckFlowers()
	{
		if (flowers.Count == 0)
		{
			Collider col = GetComponent<Collider>();
			col.enabled = false;
		}
	}
}
