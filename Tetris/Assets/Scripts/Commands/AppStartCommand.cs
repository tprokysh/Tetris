using strange.extensions.command.impl;
using System.Collections;
using UnityEngine;

public class AppStartCommand : Command
{
	[Inject]
	public IExecuter Executer { get; private set; }

	public override void Execute()
	{
		//		base.Execute(); /* idk but seems useless */
		//		Debug.Log("Test");
		Executer.Execute(WaitAndGo());
	}

	private IEnumerator WaitAndGo()
	{
		yield return new WaitForSeconds(2.0f);

		Debug.Log("Ok! Go next!");
	}
}
