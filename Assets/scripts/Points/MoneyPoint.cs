using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPoint : Point {
	protected override void OnClick() {
		Player.Global.ReceiveMoney (Monster.Global.Gold * Random.Range (0f, 1f));
		LevelController.Global.Points.Remove (gameObject);
		Destroy (gameObject);
	}
}
