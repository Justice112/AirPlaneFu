/// <summary>
/// Author: Fu
/// CreateDate: 2015 -1 -4 (:#!
/// Function:
/// </summary>
using UnityEngine;
using System.Collections;
[AddComponentMenu("MyGame/SuperEnemy")]
public class SuperEnemy : Enemy {
	public Transform mRocket;
	protected float mFireTimer = 2;
	protected Transform mPlayer ;

	void Awake () {
		GameObject obj = GameObject.FindGameObjectWithTag("Player");
		if (obj != null) {
			mPlayer = obj.transform;
		} else {
			Debug.Log("mPlayer is Null !");
		}
	}
	protected override void UpdateMove() {
		mFireTimer -= Time.deltaTime;
		if (mFireTimer <= 0) {
			mFireTimer =2;
			if (mPlayer != null) {
				Vector3 relativePos = mTransform.position - mPlayer.position;
				Instantiate (mRocket,mTransform.position,Quaternion.LookRotation(relativePos));
//				mAudio.PlayOneShot(mShootClip);
			}
		}
		mTransform.Translate(new Vector3(0,0,-mSpeed*Time.deltaTime));
	}

}
