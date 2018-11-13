using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicPlayer : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        Invoke("LoadFirstScene", 4); //calls the LoadFirstScene after 4sec
	}
	
	// Update is called once per frame
	void LoadFirstScene () {
        SceneManager.LoadScene(1);
	}
}
