using strange.extensions.command.impl;
using System.Collections;
using UnityEngine;

public class AppStartCommand : Command
{
	[Inject]
	public TetrominoView TetrominoView { get; private set; }

	public override void Execute()
	{
		for (int i = 0; i < 3; i++)
		{
			float step = 4 * i;
			Vector3 spawnPoint = new Vector3(-1.61f + step, -3.67f, 0f);
			TetrominoView.SpawnTetromino(spawnPoint);
		}
	}
}
