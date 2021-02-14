using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	static Player _uniqueInstance;

	private Animator anim;
	private CharacterController controller;

	public float speed = 15f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;
	Vector3 startPos;

	public static Player _instance
    {
		get { return _uniqueInstance; }
    }

    private void Awake()
    {
		_uniqueInstance = this;
    }

    void Start()
	{
		startPos = gameObject.transform.position;
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
        anim.SetInteger("AnimationPar", 1);

        if (controller.isGrounded) // 바닥에 서있을 때
            moveDirection = transform.forward * speed;

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) // 점프
        {
            moveDirection.y += 10f;
        }
        if (Input.touchCount > 0) // 터치가 들어오면
        {
            Touch touch = Input.GetTouch(0);
            if (touch.deltaPosition.x > 0) // 왼쪽으로 쓸어넘기면
                transform.Rotate(0, -120 * Time.deltaTime, 0);
            else
                transform.Rotate(0, 120 * Time.deltaTime, 0);

            if (touch.deltaPosition.y > 0) // 점프
            {
                moveDirection.y += 0.5f;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

	public void PlayerForTest()
    {
        controller.enabled = false;
        controller.transform.position = startPos;
        controller.enabled = true;
    }
}