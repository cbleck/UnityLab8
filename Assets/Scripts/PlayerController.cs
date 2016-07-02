using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float shootSpeed;

    private Animator playerAnimator;
    private CapsuleCollider capsule;
    private float startColliderHeight;

#if UNITY_IOS || UNITY_ANDROID
    private Vector3 accel;
    private Touch finger;

#endif
    // Use this for initialization
    void Start () {
        playerAnimator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        startColliderHeight = capsule.height;

    }
	
	// Update is called once per frame
	void Update () {

#if UNITY_STANDALONE
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
#endif
#if UNITY_IOS || UNITY_ANDROID
#endif
        accel = Input.acceleration;

        if (Input.touchCount > 0)
            finger = Input.GetTouch(0);

        playerAnimator.SetFloat(
            "direction",
            accel.x
        );

        if (Input.touchCount > 0) {

            if (finger.position.x >= Screen.width * 0.5f)
            {
                playerAnimator.SetFloat("speed", 1f);
            }

            for (int i = 1; i < Input.touchCount; i++) {

                finger = Input.GetTouch(i);
                if (finger.phase == TouchPhase.Began)
                    playerAnimator.SetTrigger("jump");
            }
        }
        else {
            playerAnimator.SetFloat("speed", 0f);
        }



        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            capsule.height = playerAnimator.GetFloat("ColliderHeight");
        else
            capsule.height = startColliderHeight;

 

    }


    public void Die() {
        StartCoroutine("DieandReplayCoroutine");
    }


    IEnumerator DieandReplayCoroutine() {

        playerAnimator.GetComponent<Collider>().enabled = false;
        playerAnimator.SetTrigger("die");

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("UnityAnimation");
    }

    IEnumerator ShootCoroutine() {

        playerAnimator.SetTrigger("shoot");

        yield return new WaitForSeconds(1);
        GameObject bullet = transform.GetChild(0).GetChild(0).gameObject;

        bullet.transform.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootSpeed, ForceMode.Impulse);

    }

}
