using System.Collections;
using UnityEngine;

public class DrakeMovement : MonoBehaviour
{
	public Transform player;
	public float speed = 5f;
	public float stopDistanceY = 0.5f;

	[Header("Attack")]
	public float waitAfterAttack = 1f;
	public FireballSpawner fireballSpawner;

	bool isAttacking = false;

	void Update()
	{
		if (isAttacking)
			return;
        float distanceY = player.position.y - transform.position.y;
        if (Mathf.Abs(distanceY) <= stopDistanceY)
        {
            StartCoroutine(AttackRoutine());
            return;
        }
        Vector3 targetPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

	IEnumerator AttackRoutine()
	{
		isAttacking = true;
		fireballSpawner.SpawnFireball();
		yield return new WaitForSeconds(waitAfterAttack);
		isAttacking = false;
	}
}
