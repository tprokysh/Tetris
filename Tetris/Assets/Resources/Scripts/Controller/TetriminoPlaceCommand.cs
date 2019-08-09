using strange.extensions.command.impl;
using strange.extensions.context.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoPlaceCommand : Command
{
	[Inject]
	public ITetriminoPieceModel tetriminoPieceModel { get; private set; }

	[Inject]
	public GameObject Tetromino { get; private set; }

	[Inject]
	public SpawnTetrominoSignal SpawnTetromino { get; private set; }

	public override void Execute()
	{
//		Debug.Log(Tetromino.name);
//		if (tetriminoPieceModel.CheckInsideField(Tetromino.transform.position))
//		{
//			Debug.Log("x: " + Mathf.Round(Tetromino.transform.position.x));
//			Debug.Log("y: " + Mathf.Round(Tetromino.transform.position.y));
//		}
//		else if (!tetriminoPieceModel.CheckInsideField(Tetromino.transform.position))
//			Debug.Log("out of field");
		if (tetriminoPieceModel.CheckInsideField(Tetromino.transform.position))
		{
			foreach (Transform mino in Tetromino.transform)
			{
				Vector3 minoPosition = tetriminoPieceModel.Round(mino.position);
//				Debug.Log("x: " + Mathf.Round(minoPosition.x));
//				Debug.Log("y: " + Mathf.Round(minoPosition.y));
				GameObject placedTetromino = GameObject.Instantiate(mino.gameObject, minoPosition, Quaternion.identity);
				tetriminoPieceModel.field[(int)minoPosition.x, (int)minoPosition.y] = placedTetromino.transform;
			}
			GameObject.Destroy(Tetromino);
			SpawnTetromino.Dispatch();
		}
	}
}
