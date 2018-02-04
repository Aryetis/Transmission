using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    SceneManager scene;

	// Use this for initialization
	void Start () {
        Invoke("LoadNextScene", 9f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadNextScene() {

        SceneManager.LoadScene(1);

    }
}
