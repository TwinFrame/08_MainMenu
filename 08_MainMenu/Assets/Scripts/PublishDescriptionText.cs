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
		_text.CrossFadeAlpha(0f, 2f, false);
		_text.text = text;
		_text.CrossFadeAlpha(1f, 2f, false);
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
}
