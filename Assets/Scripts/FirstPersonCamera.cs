using UnityEngine;
using System.Collections;

public class FirstPersonCamera : MonoBehaviour {

    public Transform targetTransform;
    public float distance;
    public float height;
    public float duration;

    private Vector3 camPosition;
	
	// Update is called once per frame
	void Update () {

        camPosition = targetTransform.position + (-distance*transform.forward) +( height * targetTransform.up);
        transform.position = Vector3.Lerp(
            transform.position, 
            camPosition, 
            Time.deltaTime * duration );

        transform.LookAt(targetTransform);
	}
}
