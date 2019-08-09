using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoView : View
{
	[Inject]
	public ITetriminoPieceModel TetriminoPieceModel { get; private set; }

	[Inject]
	public TetriminoPlaceSignal TetriminoPlaceSignal { get; private set; }

	public GameObject AudioObject { get; set; }
	private GameObject goTetromino;
	Object[] tetrominos;
	private bool isBeingHeld = false;
	private int number;
	private float startPosX;
	private float startPosY;

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
			this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
		}
	}

	private void OnMouseDown()
	{
		VFXPlayer.PlaySound("click");
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		startPosX = mousePos.x - this.transform.localPosition.x;
		startPosY = mousePos.y - this.transform.localPosition.y;
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

	private void OnMouseUp()
	{
		TetriminoPlaceSignal.Dispatch(this.gameObject);
		VFXPlayer.PlaySound("drop");
		this.gameObject.transform.localPosition = new Vector3(TetriminoPieceModel.spawPoint[number].x, TetriminoPieceModel.spawPoint[number].y, 0);
		isBeingHeld = false;
	}
}
