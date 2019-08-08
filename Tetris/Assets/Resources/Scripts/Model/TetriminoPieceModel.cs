using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoPieceModel : ITetriminoPieceModel
{
	public Vector3[] spawPoint { get; set; }
	public Transform[,] field { get; set; }

	public TetriminoPieceModel()
	{
		spawPoint = new Vector3[3];
		spawPoint[0] = new Vector3(-1.55f, -3.37f, 0f);
		spawPoint[1] = new Vector3(2f, -3.37f, 0f);
		spawPoint[2] = new Vector3(5.64f, -3.81f, 0f);
	}


}
