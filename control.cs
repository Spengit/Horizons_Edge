using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 0.125f;
    public Vector3 offset;
	void LateUpdate()
	{
		Vector3 desiredPosition = player.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(player);
	}
}
