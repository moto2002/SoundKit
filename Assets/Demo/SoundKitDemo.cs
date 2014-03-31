﻿using UnityEngine;
using System.Collections;


public class SoundKitDemo : MonoBehaviour
{
	public AudioClip explosion;
	public AudioClip fart;
	public AudioClip rocket;
	public AudioClip squish;
	public AudioClip windBGSound;

	private float _volume = 0.9f;
	private float _bgMusicVolume = 0.9f;


	public void OnGUI()
	{
		if( GUILayout.Button( "Play Explosion" ) )
			SoundKit.instance.playSound( explosion );

		if( GUILayout.Button( "Play Fart" ) )
			SoundKit.instance.playSound( fart );

		if( GUILayout.Button( "Play Fart with Completion Handler" ) )
		{
			SoundKit.instance.playSound( fart )
				.setCompletionHandler( () => Debug.Log( "done playing fart" ) );
		}

		if( GUILayout.Button( "Play Rocket" ) )
			SoundKit.instance.playSound( rocket );

		if( GUILayout.Button( "Play Squish" ) )
			SoundKit.instance.playSound( squish );

		if( GUILayout.Button( "Play Wind Background Audio" ) )
			SoundKit.instance.playBGMusic( windBGSound, true );

		if( GUILayout.Button( "Toggle AudioListener.pause" ) )
			AudioListener.pause = !AudioListener.pause;


		GUILayout.Label( "Sound Effect Volume" );

		var oldVolume = _volume;
		_volume = GUILayout.HorizontalSlider( _volume, 0, 1 );
		if( oldVolume != _volume )
			SoundKit.instance.soundEffectVolume = _volume;


		GUILayout.Label( "BG Music Volume" );

		oldVolume = _bgMusicVolume;
		_bgMusicVolume = GUILayout.HorizontalSlider( _bgMusicVolume, 0, 1 );
		if( oldVolume != _bgMusicVolume )
			SoundKit.instance.bgSound.audioSource.volume = _bgMusicVolume;
	}

}