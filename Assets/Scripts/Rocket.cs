/// <summary>
/// Author: Fu
/// CreteDate: 2015- 1 -3 @@:$$
/// Function:
/// </summary>
using UnityEngine;
using System.Collections;
[AddComponentMenu("MyGame/Rocket")]

public class Rocket : MonoBehaviour {
	public float mSpeed = 12.0f;
	public float mLiveTime = 2;
	public float mPower = 1.0f;
	protected Transform mTransform ;
	// Use this for initialization
	void Start () {
		mTransform = this.transform;
		Destroy(this.gameObject,mLiveTime);
	}
	
	// Update is called once per frame
	void Update () {
		mTransform.Translate(new Vector3(0,0,-mSpeed * Time.deltaTime));
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag.CompareTo ("Enemy") !=0) {
			return;
		} else {
			Destroy(this.gameObject);
		}
	} 
}
