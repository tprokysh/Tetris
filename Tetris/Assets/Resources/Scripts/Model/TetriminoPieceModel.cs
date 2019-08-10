using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoPieceModel : ITetriminoPieceModel
{
	public Vector3[] spawPoint { get; set; }
	public Transform[,] field { get; set; }
	public int[,] grid { get; set; }
	public bool filled { get; set; }
	public int Placed { get; set; }

	public TetriminoPieceModel()
	{
		Placed = 0;
		field = new Transform[10, 10];
		spawPoint = new Vector3[3];
		spawPoint[0] = new Vector3(-3.54f, -5.35f, 0f);
		spawPoint[1] = new Vector3(0.14f, -5.35f, 0f);
		spawPoint[2] = new Vector3(3.69f, -5.35f, 0f);
	}

	public bool CheckInsideField(Transform Tetromino)
	{
		foreach (Transform mino in Tetromino)
		{
			Vector3 minoPos = Round(mino.position);
//			Debug.Log(field[(int)minoPos.x, (int)minoPos.y]);
//			Debug.Log()
			if (!((int)minoPos.x >= 0 && (int)minoPos.x < 10 && (int)minoPos.y >= 0 && (int)minoPos.y < 10))
				return (false);
		}
		return (true);
	}

	public Vector3 Round(Vector3 position)
	{
		return new Vector3(Mathf.Round(position.x), Mathf.Round(position.y));
	}

	public void CheckIfCanDelRow()
	{
		int row;
		
		row = 0;
		while (row < 10)
		{
			CheckIsRowFilled(row);
			row++;
		}
	}

	public void CheckIsRowFilled(int row)
	{
		int col;
		int filled;

		col = 0;
		filled = 0;
		while (col < 10)
		{
			if (field[col, row] != null)
			{
				filled++;
			}
			col++;
		}
		if (filled == 10)
		{
			Debug.Log("CanDel");
			DelRow(row);
		}
	}

	public void DelRow(int row)
	{
		int col;

		col = 0;
		while (col < 10)
		{
			GameObject.Destroy(field[col, row].gameObject);
			field[col, row] = null;
			col++;
		}
	}

	public bool CheckAnotherBlock(Transform Tetromino)
	{
		foreach (Transform mino in Tetromino)
		{
			Vector3 minoPos = Round(mino.position);
			if (field[(int)minoPos.x, (int)minoPos.y] != null)
				return (false);
		}
		return (true);
	}
}
