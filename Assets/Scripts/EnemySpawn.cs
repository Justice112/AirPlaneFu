/// <summary>
/// Author: Fu
/// CreateDate: 2015 - 01 -04 !) : !@
/// Function:
/// </summary>
using UnityEngine;
using System.Collections;
[AddComponentMenu("MyGame/EnemySpawn")]
public class EnemySpawn : MonoBehaviour {
	public Transform mEnemy;
	protected float mTimer = 3;
	protected Transform mTransform;

	// Use this for initialization
	void Start () {
		mTransform = this.transform;
	}
	void OnDrawGizmos () {
		Gizmos.DrawIcon (transform.position,"item.png",true);
	}
	// Update is called once per frame
	void Update () {
		mTimer -= Time.deltaTime;
		if (mTimer <=0) {
			mTimer = Random.value * 15.0f;
			if (mTimer < 5) {
				mTimer = 5;
			} 
			Instantiate (mEnemy,mTransform.position,Quaternion.identity);
		}
	}
}
