using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickingOnSoundButtons : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private AudioMixerGroup _mixer;
	[SerializeField] private ClickingMuteEvent _clickingMuteEvent;

	private bool _isMuteEnable = true;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.pointerCurrentRaycast.gameObject.GetComponent<MuteButton>())
		{
			if (_isMuteEnable)
				_isMuteEnable = false;
			else
				_isMuteEnable = true;

			SetMute(_isMuteEnable);

			_clickingMuteEvent.Invoke(_isMuteEnable);
		}
	}

	public void SetVolumeMusic(float value)
	{
		_mixer.audioMixer.SetFloat("VolumeMusic", Mathf.Lerp(-50f, 0, value));
	}

	public void SetVolumeUI(float value)
	{
		_mixer.audioMixer.SetFloat("VolumeUI", Mathf.Lerp(-50f, 0, value));
	}

	private void SetMute(bool isEnable)
	{
		if (isEnable)
			_mixer.audioMixer.SetFloat("VolumeMaster", 0f);
		else
			_mixer.audioMixer.SetFloat("VolumeMaster", -80f);
	}

	[System.Serializable]
	public class ClickingMuteEvent : UnityEvent<bool> { }
}
