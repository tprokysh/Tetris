using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoView : View
{
	private GameObject goTetromino;
	Object[] tetrominos;
	public void SpawnTetromino(Vector3 spawnPoint)
	{
		tetrominos = Resources.LoadAll("Shapes");
		goTetromino = Instantiate(tetrominos[Random.Range(0, tetrominos.Length)], spawnPoint, Quaternion.identity) as GameObject;
	}
}
