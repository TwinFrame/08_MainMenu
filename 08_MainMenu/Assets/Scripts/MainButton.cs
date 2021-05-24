using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MainButton))]
[RequireComponent(typeof(Image))]

public class MainButton : MonoBehaviour
{
	[SerializeField] private string _name;
	[SerializeField] private int _id;

	public int id { get => _id; private set { } }
	public Text buttonText { get; private set; }

	private Image _image;

	private void Awake()
	{
		buttonText = GetComponentInChildren<Text>();
		_image = GetComponent<Image>();

		buttonText.text = _name;
	}

	public void ChangeTexture(Sprite sprite)
	{
		_image.sprite = sprite;
	}
}
