using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class MuteButton : MonoBehaviour
{
	[SerializeField] private Sprite _enable;
	[SerializeField] private Sprite _disable;

	public bool isEnable { get; private set; }

	private Image _image;

	private void Awake()
	{
		_image = GetComponent<Image>();

		isEnable = true;
	}

	public void SetSprite(bool isEnable)
	{
		if (isEnable)
			_image.sprite = _enable;
		else
			_image.sprite = _disable;
	}
}
