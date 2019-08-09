using strange.extensions.command.impl;
using System.Collections;
using UnityEngine;

public class SpawnTetrominoCommand : Command
{
	[Inject]
	public TetrominoView TetrominoView { get; private set; }
	[Inject]
	public ITetriminoPieceModel TetriminoPieceModel { get; private set; }

	public override void Execute()
	{
		for (int i = 0; i < 3; i++)
		{
			TetrominoView.SpawnTetromino(TetriminoPieceModel.spawPoint[i], i);
		}
	}
}
