using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEnding : MonoBehaviour
{
	public void Show()
	{
		// initially in the inspector, this gameObject is set to inactive 
		gameObject.SetActive(true);
		StartCoroutine(WaitForIt());

	}

	IEnumerator WaitForIt()
	{
		yield return new WaitForSeconds(3);
		gameObject.SetActive(false);
	}
}
