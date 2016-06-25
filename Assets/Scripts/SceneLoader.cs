using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public bool appear;
    public GameObject description, infoButton, returnButton;


	// Use this for initialization
	void Start () {

        appear = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        description.SetActive(appear);
        returnButton.SetActive(appear);
        infoButton.SetActive(!appear);
	
	}

    public void toggleInfo() {
        appear = !appear;
    }

    public void loadFirstLevel() {
        EditorSceneManager.LoadScene(1);
    }
}
