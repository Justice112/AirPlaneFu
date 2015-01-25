/// <summary>
/// Author: Fu
/// CreateDate: 2015 - 01-3 @#:$(
/// Function:
/// 
/// </summary>
using UnityEngine;
using System.Collections;
[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour {
	public float mSpeed = 1;
	protected float mRotSpeed = 30;
	protected Transform mTransform;
	public float mLife = 10;
	public AudioClip mShootClip;
	protected AudioSource mAudio;
	public Transform mExplosionFX;		// 
	public int mPoint = 10;
	// Use this for initialization
	void Start () {
		mTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMove();
	}
	protected virtual void UpdateMove () {
		// 左右移动
		float rx = Mathf.Sin(Time.time) * Time.deltaTime;	
		// 前进
		mTransform.Translate(new Vector3(rx,0,-mSpeed * Time.deltaTime));
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag.CompareTo("PlayerRocket") == 0) {
			Rocket rocket = other.GetComponent<Rocket>();
			if (rocket !=null) {
				mLife -= rocket.mPower;
				if (mLife <= 0) {
					Instantiate (mExplosionFX,mTransform.position,Quaternion.identity);
					Destroy (this.gameObject);
				}
			}
		} else if (other.tag.CompareTo("Player") == 0) {
			mLife = 0;
			Instantiate (mExplosionFX,mTransform.position,Quaternion.identity);
			Destroy(this.gameObject);
		} 
		if (other.tag.CompareTo("Bound") == 0) {
			mLife = 0;
			Instantiate (mExplosionFX,mTransform.position,Quaternion.identity);
			Destroy(this.gameObject);
		}
		if (mLife <= 0) {
			GameManager.Instance.AddScore(mPoint);
			Instantiate(mExplosionFX,mTransform.position,Quaternion.identity);
			Destroy(this.gameObject,0.1f);
		}
	}
}
