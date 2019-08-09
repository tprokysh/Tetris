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
		spawPoint[0] = new Vector3(-0.6360393f, -2.826441f, 0f);
		spawPoint[1] = new Vector3(3.02f, -2.826441f, 0f);
		spawPoint[2] = new Vector3(6.57f, -2.826441f, 0f);
		field = new Transform[10, 10];
	}

	public bool CheckInsideField(Vector3 position)
	{
		return ((int)position.x >= 0 && (int)position.x < 10 && (int)position.y >= 0);
	}

	public Vector3 Round(Vector3 position)
	{
		return new Vector3(Mathf.Round(position.x), Mathf.Round(position.y));
	}
}
