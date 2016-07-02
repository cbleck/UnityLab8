using UnityEngine;
using System.Collections;

public class FirstPersonCameraBetter : MonoBehaviour {

    public Transform targetTransform;
    public float smooth = 0.3f;
    public float distance = 5f;
    public float height = 5f;
    public float yVelocity = 0f;

    private Vector3 camPosition;
	
	// Update is called once per frame
	void Update () {

        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                                            targetTransform.eulerAngles.y,
                                            ref yVelocity, smooth);

        Vector3 position = targetTransform.position;
        position += Quaternion.Euler(0, yAngle, 0) * new Vector3(0, height, -distance);
        transform.position = position;
        transform.LookAt(targetTransform);
	}
}
