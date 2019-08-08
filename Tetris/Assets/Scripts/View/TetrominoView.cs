using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoView : View
{
	[Inject]
	public ITetriminoPieceModel TetriminoPieceModel { get; private set; }
	private GameObject goTetromino;
	Object[] tetrominos;
	private bool isBeingHeld = false;
	public Vector3 initPos;
	public int number;
	public void SpawnTetromino(Vector3 spawnPoint, int number)
	{
		tetrominos = Resources.LoadAll("Shapes");
		goTetromino = Instantiate(tetrominos[Random.Range(0, tetrominos.Length)], spawnPoint, Quaternion.identity) as GameObject;
		goTetromino.AddComponent<TetrominoView>();
		this.number = number;
	}

	private void Update()
	{
		if (isBeingHeld)
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
		}
	}

	private void OnMouseDown()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			isBeingHeld = true;
			if (this.gameObject.transform.localPosition == TetriminoPieceModel.spawPoint[0])
			{
				number = 0;
			}
			if (this.gameObject.transform.localPosition == TetriminoPieceModel.spawPoint[1])
			{
				number = 1;
			}
			if (this.gameObject.transform.localPosition == TetriminoPieceModel.spawPoint[2])
			{
				number = 2;
			}
		}
	}

	private void OnMouseUp()
	{
		this.gameObject.transform.localPosition = new Vector3(TetriminoPieceModel.spawPoint[number].x, TetriminoPieceModel.spawPoint[number].y, 0);
		isBeingHeld = false;
	}
}
