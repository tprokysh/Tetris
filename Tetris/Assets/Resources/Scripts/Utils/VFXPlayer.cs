using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXPlayer : MonoBehaviour
{
	public static AudioClip click;
	public static AudioClip drop;
	static AudioSource audioSrc;

	void Start()
	{
		click = Resources.Load<AudioClip>("VFX/Click");
		drop = Resources.Load<AudioClip>("VFX/Drop");

		audioSrc = GetComponent<AudioSource>();
	}

	public static void PlaySound (string clip)
	{
		switch (clip)
		{
			case "click":
				audioSrc.PlayOneShot(click);
				break;
			case "drop":
				audioSrc.PlayOneShot(drop);
				break;
		}
	}
}
