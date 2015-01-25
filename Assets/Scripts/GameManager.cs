/// <summary>
/// Author: Fu
/// CreateDate: 2015 -1-4
/// Function:
/// </summary>
using UnityEngine;
using System.Collections;
[AddComponentMenu("MyGame/GameManager")]
public class GameManager : MonoBehaviour {
	public static GameManager Instance;
	public int mScore = 0;
	public static int mHiscore = 0;
	protected Player mPlayer;
	public AudioClip mMusicClip;
	protected AudioSource mAudio;
	void Awake() {
		Instance = this;
	}
	// Use this for initialization
	void Start () {
		mAudio = this.audio;
		GameObject obj = GameObject .FindGameObjectWithTag("Player");
		if (obj !=null) {
			mPlayer = obj.GetComponent<Player>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!mAudio.isPlaying) {
			mAudio.clip = mMusicClip;
			mAudio.Play();
		}
		if (Time.timeScale >0 && Input.GetKeyDown(KeyCode.Escape)) {
			Time.timeScale = 0;
		}
	}
	void OnGUI () {
		if (Time.timeScale == 0) {
			if (GUI.Button(new Rect (Screen.width * 0.5f - 50, Screen.height * 0.4f , 100,30)," GO ON")) {
				Time.timeScale = 1;
			}
			if (GUI.Button(new Rect (Screen.width * 0.5f - 50, Screen.height * 0.6f , 100,30)," Quit")) {
				Application.Quit();
			}
		}
		int life = 0;
		if (mPlayer != null ) {
			life = (int) mPlayer.mLife;
		} else {
			GUI.skin.label.fontSize = 50;
			GUI.skin.label.alignment = TextAnchor.LowerCenter;
			GUI.Label (new Rect ( 0 , Screen.height * 0.2f,Screen.width, 60)," Game Over");
			GUI.skin.label.fontSize = 20;
			if (GUI.Button (new Rect(Screen.width * 0.5f- 50,Screen.height * 0.5f, 100,30),"Try Again")) {
				Application.LoadLevel(Application.loadedLevelName);
			}
		} 
		GUI.skin.label.fontSize = 15;
		GUI.Label(new Rect(5,5,100,30), "Life"+ life);
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label(new Rect(0,5,Screen.width,30),"Score" +mScore);

	}
	public void AddScore (int point) {
		mScore +=point;
		if (mHiscore < mScore) {
			mHiscore = mScore;
		}
	}
}
