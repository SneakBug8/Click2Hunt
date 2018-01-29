using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "gameAssets/Card")]
public class Card : ScriptableObject {
	public string Name;

	public int Health;
	public int Damage;
	[Space]
	public Sprite Sprite;
}
