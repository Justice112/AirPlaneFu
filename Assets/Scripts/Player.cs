/// <summary>
/// Author: Fu
/// CreteDate: 2015- 1 -3 @):%)
/// Function:
/// </summary>
using UnityEngine;
using System.Collections;
[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour {
	public float mSpeed = 1;
	protected Transform mTransform;
	public Transform mRocket;
	public  float mRocketRate =0;
	public float mLife = 3;
	public AudioClip mShootClip;
	protected AudioSource mAudio;
	public Transform mExplosionFX;		// 
	protected Vector3 mTargetPos;
	public LayerMask mInputMask;		// 

	// Use this for initialization
	void Start () {
		mTransform = this.transform;
		mAudio = this.audio;
		mTargetPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float moveV = 0;
		float moveH = 0;
		mRocketRate -= Time .deltaTime;
		if (Input .GetKey(KeyCode.UpArrow)) {
			moveV -= mSpeed * Time.deltaTime;
		}
		if (Input .GetKey(KeyCode.DownArrow)) {
			moveV += mSpeed * Time.deltaTime;
		}
		if (Input .GetKey(KeyCode.LeftArrow)) {
			moveH += mSpeed * Time.deltaTime;
		}
		if (Input .GetKey(KeyCode.RightArrow)) {
			moveH -= mSpeed * Time.deltaTime;
		}
		mTransform.Translate(new Vector3(moveH,0,moveV));
		if (mRocketRate <= 0) {
			mRocketRate = 0.1f;
			if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
				Instantiate(mRocket,mTransform.position,mTransform.rotation);
				mAudio.PlayOneShot(mShootClip);
			}
		}
		MoveTo();
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag.CompareTo("PlayerRocket") != 0) {
			mLife -=1;
			if (mLife <= 0) {
				Instantiate (mExplosionFX,mTransform.position,Quaternion.identity);
				Destroy(this.gameObject);
			}
		}
	}
	void MoveTo () {
		if (Input.GetMouseButton(0)) {
			Vector3 ms = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay(ms);
			RaycastHit hitInfo;
			bool isCast = Physics.Raycast(ray,out hitInfo,1000,mInputMask);
			if (isCast) {
				mTargetPos = hitInfo.point;
			}
		}
		Vector3 pos = Vector3.MoveTowards(this.mTransform.position,mTargetPos,mSpeed*Time.deltaTime);
		this.mTransform.position = pos;
	}
}
