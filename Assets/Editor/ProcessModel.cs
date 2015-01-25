/// <summary>
/// Author: Fu
/// CreateDate: 2015-1-4  !#:@^
/// Function:
/// </summary>
using UnityEngine;
using UnityEditor;
using System.Collections;

public class ProcessModel : AssetPostprocessor {
	void OnPostprocessModel (GameObject input) {
		// 只处理名为“Enemy2b” 的模型
		if (!input.name.Contains("Enemy2b"))   return;
		// 设置导入模型的 tag
		input.tag= "Enemy";

		foreach (Transform obj in input.GetComponentsInChildren<Transform>()) {
			if (obj.name.CompareTo("col") == 0) {
				MeshRenderer r = obj.GetComponent<MeshRenderer>();
				r.enabled = false;		// 取消碰撞模型的显示
				// 添加Mesh 碰撞体
				obj.gameObject.AddComponent<MeshCollider>();
				// 设置碰撞体的tag
				obj.tag = "Enemy";
			}
		}
		// 设置刚体
		Rigidbody rigid = input.AddComponent<Rigidbody>();
		rigid.useGravity = false;
		rigid.isKinematic = true;
		// 取得导入模型的相关信息
		ModelImporter importer = assetImporter as ModelImporter;
		// 从工程中将该模型读取出来
		GameObject tar = (GameObject) AssetDatabase.LoadAssetAtPath(importer.assetPath, typeof(GameObject));
		// 将这个模型创建为Prefab
		GameObject prefab = (GameObject) PrefabUtility.CreatePrefab("Assets/Prefabs/Enemy2c.prefab",tar);
		// 添加声音组件
		prefab.AddComponent<AudioSource>();
		// 获得子弹的prefab
		GameObject rocket = (GameObject) AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EnemyRockey.prefab",typeof (GameObject));
		// 获得爆炸效果的Prefab
		GameObject fx = (GameObject) AssetDatabase.LoadAssetAtPath("Assets/FX/Explosion.prefab",typeof(GameObject));
		// 添加脚本
		SuperEnemy enemy = prefab.AddComponent<SuperEnemy>();
		// 设置默认参数
		enemy.mLife = 50;
		enemy.mPoint = 50;
		enemy.mRocket = rocket.transform;
		enemy.mExplosionFX = fx.transform;
	}

}
