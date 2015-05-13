﻿using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//public GameObject Enemy;
	//public GameObject Enemy2;
	public Material[] randomMaterials;
	public GameObject[] Enemy;
	public GameObject Portals;
	public GameObject Text;
	public float SpawnTimer;
	public float EnemySpawnCounter;
	public float LevelCounter;
	public int num;

	void Spawn() {
		int prefab_num = Random.Range (0,9);
		Vector3 newPosition = new Vector3(Random.insideUnitSphere.x * 50, transform.position.y, Random.insideUnitSphere.z * 50);
		Instantiate(Enemy[prefab_num], newPosition, transform.rotation);
		--EnemySpawnCounter;
	}
	// Use this for initialization
	void Start () {
		LevelCounter = 1;
		num = Random.Range (1, 10);
		EnemySpawnCounter = LevelCounter * 5 * num;
		StartCoroutine(countdown(EnemySpawnCounter));
		Debug.Log (EnemySpawnCounter);
	}
	// Update is called once per frame
	void Update () {
		int enemyCount = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		//Debug.Log (enemyCount);
		Debug.Log (EnemySpawnCounter);
		if (enemyCount <= 0 && EnemySpawnCounter <= 0)
		{
			Text.SetActive(true);
			Portals.SetActive(true);
		}
	}

	IEnumerator countdown(float time)
	{
		int i = 0;
		while (i < time) {
			Spawn();
			yield return new WaitForSeconds(5.0f);
			--time;
		}
	}
}