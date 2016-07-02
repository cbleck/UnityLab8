using UnityEngine;
using System.Collections;

public class CameraCinematic : MonoBehaviour {

    public void StartCinematic() {
        Time.timeScale = 0f;
    }

    public void EndCinematic() {

        Time.timeScale = 1f;
        GetComponent<FirstPersonCameraBetter>().enabled = true;
    }
}
