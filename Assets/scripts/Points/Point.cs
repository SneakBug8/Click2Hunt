using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
	readonly Vector3 RotationPerSecond = new Vector3 (0, 0, 120);
	BoxCollider2D collider;

	void Start() {
		collider = GetComponent<BoxCollider2D> ();
	}

	void Update () {
		// Check clicks
		for (var i = 0; i < Input.touchCount; ++i) {
			var touch = Input.GetTouch (i);
			if (touch.phase == TouchPhase.Began && touch.deltaPosition.magnitude <= 1) {
				RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
				if(hitInfo.collider == collider)
				{
					OnClick ();
				}
			}
		}

		transform.Rotate (RotationPerSecond * Time.deltaTime);
	}

	void OnMouseDown()
	{
		OnClick ();
	}

	protected virtual void OnClick() {
		Destroy (gameObject);
	}
}
