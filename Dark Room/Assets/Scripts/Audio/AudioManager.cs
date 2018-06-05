﻿using UnityEngine.Audio; 
using System; 
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	void Awake () 
	{
		foreach (Sound s in sounds) 
		{
			s.source = gameObject.AddComponent<AudioSource> (); 
			s.source.clip = s.clip; 
			s.source.volume = s.volume;
			s.source.pitch = s.pitch; 
			s.source.loop = s.loop; 
		}
	}

	void Start ()
	{
		//Play ("Theme"); 
	} 

	public void Play (string name)
	{
		Sound s = Array.Find (sounds, Sound => Sound.name == name); 
		s.source.Play (); 
	}

    public void Stop(string name) 
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        s.source.Stop();
    }
}
