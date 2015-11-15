using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public AudioClip[] sfx;
	private AudioSource source;
	public static AudioManager instance;
	// Use this for initialization
	void Awake () {
		instance = this;
		source = GetComponent<AudioSource>();
		
		DontDestroyOnLoad(gameObject);
	}
	
	public void playSound(int i){
		source.PlayOneShot(sfx[i]);
	}
	
	public void playSound(AudioClip a){
		source.PlayOneShot(a);
	}
}
