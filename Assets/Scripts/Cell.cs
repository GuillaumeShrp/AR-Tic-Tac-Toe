using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell : MonoBehaviour
{

	public event EventHandler click;

	private TMPro.TextMeshPro _text;

	public bool IsEnabled { get; set; } = true;

	public void SetText(string text)
	{
		if (_text == null)
		{
			_text = GetComponentInChildren<TMPro.TextMeshPro>();
		}
		_text.text = text;
	}

	private void OnMouseDown()
	{
		if (!IsEnabled) return; 
		click?.Invoke(this, EventArgs.Empty);
		// click is the Eventhandler 
		// ('this' is the event sender which is the cell)
	}

}
