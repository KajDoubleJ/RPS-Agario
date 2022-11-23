using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	private Vector3 Change;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void Update()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref Change, smoothSpeed);
		transform.position = smoothedPosition;

		//transform.LookAt(target);
	}
}
