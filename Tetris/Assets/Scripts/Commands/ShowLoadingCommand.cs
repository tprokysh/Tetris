using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLoadingCommand : Command
{
	public override void Execute() /* Needs to override!!! */
	{
		Debug.Log("Show loading");
	}
}
