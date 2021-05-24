using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClickingOnMainButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[Header("Button Stage Sprites")]
	[SerializeField] private Sprite _default;
	[SerializeField] private Sprite _onDown;
	[SerializeField] private Sprite _onUp;

	[Header("On Click Up")]
	[SerializeField] private OnUpFloatEvent _onUpFloatEvent;
	[SerializeField] private OnUpIntEvent _onUpIntEvent;

	private MainButton _currentMainButton;
	private MainButton _currentMainButtonOnDown;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.pointerPressRaycast.gameObject.TryGetComponent<MainButton>(out MainButton mainButton))
		{
			if (_currentMainButton != null)
			{
				_currentMainButton.ChangeTexture(_default);
			}

			_currentMainButtonOnDown = mainButton;

			_currentMainButtonOnDown.ChangeTexture(_onDown);

			return;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{

		if (eventData.pointerCurrentRaycast.gameObject.TryGetComponent<MainButton>(out MainButton mainButton))
		{
			if (_currentMainButton == mainButton)
			{
				_currentMainButtonOnDown.ChangeTexture(_default);
			}

			if (_currentMainButtonOnDown != mainButton)
			{
				_currentMainButton.ChangeTexture(_default);
				_currentMainButtonOnDown.ChangeTexture(_default);
			}

			SetCurrentMainButtonOnClickUp(mainButton);

			return;
		}

		if (_currentMainButtonOnDown != null)
		{
			SetCurrentMainButtonOnClickUp(_currentMainButtonOnDown);
		}
	}

	private void SetCurrentMainButtonOnClickUp(MainButton button)
	{
		_currentMainButton = button;

		_currentMainButton.ChangeTexture(_onUp);

		_onUpFloatEvent.Invoke(_currentMainButton.transform.position.y);
		_onUpIntEvent.Invoke(_currentMainButton.id);
	}

	[System.Serializable]
	public class OnUpFloatEvent : UnityEvent<float> { }

	[System.Serializable]
	public class OnUpIntEvent : UnityEvent<int> { }
}
