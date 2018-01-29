﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPSPoint : MonoBehaviour {
	readonly Vector3 RotationPerSecond = new Vector3 (0, 0, 120);

	void Update () {
		// Check clicks
		for (var i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
				if(hitInfo)
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

	void OnClick() {
		DPS.Global.DamagePerSecond += Monster.Global.MonsterIndex;
		Destroy (gameObject);
	}
}