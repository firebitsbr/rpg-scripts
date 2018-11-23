﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public static class LevelLoaderInfo {
	public static int levelIndex { get; set; }
}

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;

	void Start () 
	{
		LoadLevel (LevelLoaderInfo.levelIndex);
	}

	public void LoadLevel(int sceneIndex) 
	{
		StartCoroutine (LoadAsynchronously (sceneIndex));
	}

	IEnumerator LoadAsynchronously (int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		loadingScreen.SetActive (true);

		while (!operation.isDone) {

			float progress = Mathf.Clamp01 (operation.progress / .9f);
			Debug.Log (progress);

			slider.value = progress;

			yield return null;
		}
	}
}
