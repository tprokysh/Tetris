using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineWorker : MonoBehaviour
{

}

public class CoroutineExecuter : IExecuter
{
	private readonly CoroutineWorker coroutineWorker;

	public CoroutineExecuter()
	{
		var gameObject = new GameObject("CoroutineWorker");
		coroutineWorker = gameObject.AddComponent<CoroutineWorker>();
	}

	public void Execute(IEnumerator coroutine)
	{
		coroutineWorker.StartCoroutine(coroutine);
	}
}
