using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(KnobSpot))]

public class KnobSpot : MonoBehaviour
{
	[SerializeField] private UnityEvent _moveKnobSpot;

	private float _currentPositionY;

	private void Awake()
	{
		_currentPositionY = transform.position.y;
	}

	public void MoveOnY(float positionY)
	{
		transform.DOMoveY(positionY, 0.2f).SetEase(Ease.InOutElastic);

		if (_currentPositionY != positionY)
		{
			_moveKnobSpot.Invoke();
		}

		_currentPositionY = positionY;
	}
}
