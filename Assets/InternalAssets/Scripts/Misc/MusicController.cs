using UnityEngine;

public class MusicController : MonoBehaviour {

	private static MusicController _instance;
	public static MusicController Instance
	{
		get { return _instance; }
	}

	public AudioSource introAudiosource;
	public AudioSource loopAudiosource;

	public Music[] musics;
	[System.Serializable]
	public struct Music
	{
		public AudioClip intro;
		public AudioClip loop;
	}

	private void Awake()
	{
		// Singleton instance
		if (_instance != null)
		{
			Debug.LogError("Two MusicController detected. Removing one of them.");
			Destroy(gameObject);
		}
		else
		{
			_instance = this;
		}

		transform.SetParent(null);
		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		PlayMusic(0);
	}

	private void PlayMusic(int musicID)
	{
		Music music = musics[musicID];
		introAudiosource.clip = music.intro;
		introAudiosource.Play();
		loopAudiosource.clip = music.loop;
		loopAudiosource.PlayDelayed(music.intro.length);
	}

	public void SetMusicVolume (float volume)
	{
		introAudiosource.volume = volume;
		loopAudiosource.volume = volume;
	}
}
