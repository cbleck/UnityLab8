using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float shootSpeed;
	public GameObject bullet;

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

        if (Input.GetKeyDown(KeyCode.O))
            StartCoroutine("ShootCoroutine");
        if (Input.GetKeyDown(KeyCode.H))
            playerAnimator.SetTrigger("wave");

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            capsule.height = playerAnimator.GetFloat("ColliderHeight");
        else
            capsule.height = startColliderHeight;

    }


    public void Die() {
        StartCoroutine("DieandReplayCoroutine");
    }


    IEnumerator DieandReplayCoroutine() {

        capsule.enabled = false;
        playerAnimator.SetTrigger("die");

        yield return new WaitForSeconds(2.5f);
	capsule.enabled = true;
        SceneManager.LoadScene("UnityAnimation");
    }

    IEnumerator ShootCoroutine() {

        playerAnimator.SetTrigger("shoot");

        yield return new WaitForSeconds(1);
        GameObject bullet = transform.GetChild(0).GetChild(0).gameObject;

        //bullet.transform.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootSpeed, ForceMode.Impulse);

    }

}
