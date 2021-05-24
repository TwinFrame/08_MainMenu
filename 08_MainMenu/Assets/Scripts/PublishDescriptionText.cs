using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[RequireComponent(typeof(Text))]

public class PublishDescriptionText : MonoBehaviour
{
	private Text _text;
	private string _commonPath = "Assets/DescriptionText/Text";
	private string _path;
	private string _currentLine = "";
	private string _currentText;
	private Coroutine _changeTextJob;

	private void Awake()
	{
		_text = GetComponentInChildren<Text>();
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

		_changeTextJob = StartCoroutine(ChangeText(0.5f, text));
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
		Color color;
		float currentTime = 0;

		while (currentTime <= duration)
		{
			color.a = 1 - currentTime / duration;

			_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, color.a);

			currentTime += Time.deltaTime;

			yield return null;
		}

		_text.text = text;

		currentTime = 0;

		while (currentTime <= duration)
		{
			color.a = currentTime / duration;

			_text.color = new Color(_text.color.r, _text.color.g, _text.color.b, color.a);

			currentTime += Time.deltaTime;

			yield return null;
		}
	}
}
