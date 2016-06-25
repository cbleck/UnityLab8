using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Animator playerAnimator;
    private CapsuleCollider capsule;
    private float startColliderHeight;

	// Use this for initialization
	void Start () {
        playerAnimator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        startColliderHeight = capsule.height;

    }
	
	// Update is called once per frame
	void Update () {
        playerAnimator.SetFloat(
            "direction",
            Input.GetAxis("Horizontal")
        );
        playerAnimator.SetFloat(
            "speed",
            Input.GetAxis("Vertical")
        );

        if ((Input.GetKeyDown(KeyCode.Space))
             && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
            playerAnimator.SetTrigger("jump");

        if (Input.GetKeyDown(KeyCode.H))
            playerAnimator.SetTrigger("wave");

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            capsule.height = playerAnimator.GetFloat("ColliderHeight");
        else
            capsule.height = startColliderHeight;
    }
}
