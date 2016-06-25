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
            //Input.GetAxis("Vertical")
            Vector3.Magnitude(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")))
        );

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 3"))
             && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
            playerAnimator.SetTrigger("jump");

        if (Input.GetKeyDown(KeyCode.H))
            playerAnimator.SetTrigger("wave");

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            capsule.height = playerAnimator.GetFloat("ColliderHeight");
        else
            capsule.height = startColliderHeight;

    }


    public void Die() {
        playerAnimator.GetComponent<Collider>().enabled = false;
        playerAnimator.SetTrigger("die");
    }

}
