/// <summary>
/// Author: Fu
/// CreateDate: 2015-1-4 !$:)^
/// Function:代码优化，缓存清理
/// 
/// 
/// </summary>
using UnityEngine;
using System.Collections;

public class CachedObject : MonoBehaviour {
	public bool inUse {set; get;}		// 是否在使用中
	protected GameObject _asset = null;		// 资源
	protected ParticleSystem [] _ps;


	// 创建一个缓存资源
	public static CachedObject Create (string assetName, GameObject prefab) {
		GameObject go = new GameObject();
		go.name = "cache_" + assetName;
		CachedObject co = go.AddComponent<CachedObject>();
		co.Init(assetName,prefab);
		return co;

	}

	// 缓存一个游戏体
	void Init (string assetName, GameObject prefab) {
		inUse = false;
		// 创建资源并移动到看不见的地方
		Vector3 pos = new Vector3(1000,1000,1000);
		_asset = (GameObject ) GameObject .Instantiate(prefab,pos,Quaternion.identity);
		_ps = _asset.GetComponentsInChildren<ParticleSystem>();
		// 隐藏这个资源
		_asset.SetActive(false);
	}

	// 在游戏中创建资源（将隐藏的资源显示出来）
	public GameObject CreateAsset (Vector3 pos , Vector3 euler) {
		if (_asset == null) {
			return null;
		}
		inUse = true;
		this.transform.position = pos;
		this.transform.eulerAngles = euler;
		// 显示资源
		_asset .SetActive(true);
		// 显示资源中得粒子
		foreach ( ParticleSystem ps in _ps) {
			ps.Play(true);
		}
		return _asset;
	}

	/// <summary>
	/// 清除缓存资源（不是真的清除，只是隐藏了）
	/// </summary>
	/// <returns>The asset.</returns>
	public GameObject DestoryAsset() {
		if (_asset == null) {
			return null;
		}
		inUse = false;
		this.transform.position = new Vector3 (1000,1000,1000);
		this.transform.eulerAngles = Vector3.zero;
		// 隐藏
		_asset.SetActive (false);
		// 停止粒子运动
		foreach (ParticleSystem ps in _ps) {
			ps.Stop(true);
		}
		return _asset;
	}
	//使用如下:
//	CachedObject cached = CachedObject .Create("assetName",someprefab);
//	cached.CreateAsset(Vector3.zero,Vector3.zero);
//	CachedObject.destoryAsset();
}
