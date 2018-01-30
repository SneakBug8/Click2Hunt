using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Configs/SoundLibrary")]
public class SoundLibrary : ScriptableObject {
	public AudioClip OnButtonClick;
	public AudioClip OnShot;
	public AudioClip OnMonsterAttack;
	public AudioClip OnMonsterDeath;
	public AudioClip OnBought;
}
