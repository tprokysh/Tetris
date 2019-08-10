using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITetriminoPieceModel
{
	Vector3[] spawPoint { get; set; }
	Transform[,] field { get; set; }
	int[,] grid { get; set; }
	bool CheckInsideField(Transform Tetromino);
	bool CheckAnotherBlock(Transform Tetromino);
	Vector3 Round(Vector3 position);
	void CheckIfCanDelRow();
	void CheckIsRowFilled(int row);
	void DelRow(int row);
	int Placed { get; set; }
}
