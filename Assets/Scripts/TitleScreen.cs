/// <summary>
/// Author: Fu
/// CreateDate: 2015-1-4
/// Function:
/// </summary>
using UnityEngine;
using System.Collections;
[AddComponentMenu("MyGame/TitleScreen")]
public class TitleScreen : MonoBehaviour {
	void OnGUI () {
		GUI.skin.label.fontSize = 48;
		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label(new Rect (0,30,Screen.width,100) ,"AirWar");
		if (GUI.Button (new Rect(Screen.width * 0.5f -100, Screen.height *0.7f,200,30),"Begin Game")) {
			Application.LoadLevel("level1");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
