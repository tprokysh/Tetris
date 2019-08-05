using strange.extensions.command.impl;
using System.Collections;
using UnityEngine;

public class AppStartCommand : Command
{
	public override void Execute()
	{
//		base.Execute(); /* idk but seems useless */
		Debug.Log("Test");
	}
}
