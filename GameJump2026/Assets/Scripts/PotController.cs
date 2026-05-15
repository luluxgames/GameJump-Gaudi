using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
	public List<GameObject> flowers;

	public void AddFlower(int quantity = 1)
	{
		for (int i = 0; i < quantity; i++)
		{
			flowers[i].SetActive(true);
			flowers.RemoveAt(i);
			GameManager.Instance.flowersCollected++;
		}
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
