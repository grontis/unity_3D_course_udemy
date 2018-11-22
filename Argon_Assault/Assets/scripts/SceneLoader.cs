using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Invoke("LoadFirstScene", 4); //calls the LoadFirstScene after 4sec
	}
	
	// Update is called once per frame
	void LoadFirstScene () {
        SceneManager.LoadScene(1);
	}
}
