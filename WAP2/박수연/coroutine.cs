using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutine : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(RepeatMessage(5, 1.0f, "Hello!"));
	}

	IEnumerator RepeatMessage(int count, float frequency, string message)
	{
		for (int i = 0; i < count; i++)
		{
			Debug.Log(message);
			for (float timer = 0; timer < frequency; timer += Time.deltaTime)
			{
				yield return 0;
			}
		}
	}
}
