using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[RequireComponent(typeof(Text))]

public class PublishDescriptionText : MonoBehaviour
{
	[SerializeField] private float _timeFadeText;
	private Text _text;
	private string _commonPath = "Assets/DescriptionText/Text";
	private string _path;
	private string _currentLine = "";
	private string _currentText;

	private Color _currentColor;

	private Coroutine _changeTextJob;

	private void Awake()
	{
		_text = GetComponentInChildren<Text>();

		_currentColor = _text.color;
	}

	public void PublishTextAsButtonID(int id)
	{
		PublishText(LoadTextFromFile(id));
	}

	private void PublishText(string text)
	{
		if (_changeTextJob != null)
		{
			StopCoroutine(_changeTextJob);
		}

		_changeTextJob = StartCoroutine(ChangeText(_timeFadeText, text));
	}

	private string LoadTextFromFile(int id)
	{
		_path = _commonPath + id + ".txt";

		StreamReader streamReader = new StreamReader(_path);

		_currentText = "";

		while (!streamReader.EndOfStream)
		{
			_currentLine = streamReader.ReadLine();

			if (_currentText == "")
				_currentText += _currentLine;
			else
				_currentText += "\n" + _currentLine;
		}

		return _currentText;
	}

	private IEnumerator ChangeText(float duration, string text)
	{
		float currentTime = 0;

		while (currentTime <= duration)
		{
			_currentColor.a = 1 - currentTime / duration;

			_text.color = _currentColor;

			currentTime += Time.deltaTime;

			yield return null;
		}

		_text.text = text;

		currentTime = 0;

		while (currentTime <= duration)
		{
			_currentColor.a = currentTime / duration;

			_text.color = _currentColor;

			currentTime += Time.deltaTime;

			yield return null;
		}
	}
}
