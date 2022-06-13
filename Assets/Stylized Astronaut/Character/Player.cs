using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject playerCamera, carCamera;
	public static bool inCar;

	private Animator anim;
	private Rigidbody rb;

	public float speed = 600.0f;
	public float turnSpeed = 400.0f;
	public float jumpForce = 450f;
	private float moveDirection;

	void Start() {
		rb = GetComponent<Rigidbody>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update() {
		if (!PlayerHealth.isDeath) {
			if (Input.GetKey("w"))
				anim.SetInteger("AnimationPar", 1);
			else
				anim.SetInteger("AnimationPar", 0);

			moveDirection = Input.GetAxis("Vertical") * speed * Time.deltaTime;
			rb.MovePosition(transform.position + transform.forward * moveDirection);

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

			if (rb.velocity.y == 0)
				anim.SetBool("isJump", false);

			if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0) {
				rb.AddForce(Vector3.up * jumpForce);
				anim.SetTrigger("Jumping");
				anim.SetBool("isJump", true);
			}
		}
	}

	private void OnTriggerStay(Collider other) {
		if (other.GetComponent<CarController>()) {
			if (Input.GetKeyDown(KeyCode.E) && !inCar) {
				rb.transform.parent = other.transform;
				carCamera.SetActive(true);
				gameObject.SetActive(false);
				inCar = true;
			}
		}
	}

	public void ExitCar() {
		transform.localPosition = new Vector3(3f, 0.1f, 0f);
		carCamera.SetActive(false);
		gameObject.SetActive(true);
		rb.transform.parent = null;
		inCar = false;
	}
}