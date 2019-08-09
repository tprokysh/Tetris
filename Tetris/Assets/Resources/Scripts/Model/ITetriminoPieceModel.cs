using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITetriminoPieceModel
{
	Vector3[] spawPoint { get; set; }
	Transform[,] field { get; set; }
	bool CheckInsideField(Vector3 position);
	Vector3 Round(Vector3 position);
}
