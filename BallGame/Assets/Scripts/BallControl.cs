using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    private Rigidbody ballRigidbody;
    private Renderer ballRenderer;

    [SerializeField]
    private GameObject deathSystem;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask groundLayer;

    private float horizontalMove;
    private float verticalMove;
    private bool jump;
    private bool dead;

    // Use this for initialization
    void Start ()
    {
        ballRenderer = GetComponent<Renderer>();
        ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.velocity = new Vector3(0, 0, speed);

        dead = false;
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void FixedUpdate ()
    {
        if (!dead)
        {
            HandleMovement();
            CheckDeathByFall();
        }
    }

    private void HandleInput()
    {
        //Left Right
        horizontalMove = 0;
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width * 2 / 3)
                horizontalMove = speed/2;
            else if (Input.mousePosition.x < Screen.width / 3)
                horizontalMove = -speed/2;
        }

        //jump
        if (Input.GetMouseButtonDown(0))
        {
            verticalMove = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
        {
            verticalMove = verticalMove - Input.mousePosition.y;
            if (verticalMove < -Screen.height / 4)
            {
                jump = true;
            }
            verticalMove = 0;
        }
        //horizontalMove = Input.GetAxis("Horizontal");
    }
    private void HandleMovement()
    {
        ballRigidbody.velocity = new Vector3(horizontalMove, ballRigidbody.velocity.y, speed);

        if (jump && IsOnGround())
        {
            ballRigidbody.AddForce(new Vector3(0, jumpForce, 0));
            jump = false;
        }
    }

    private bool IsOnGround()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1, groundLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstackle"))
        {
            Die();
        }
    }

    private void CheckDeathByFall()
    {
        if (transform.position.y < -3.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        dead = true;

        ballRenderer.GetComponent<MeshRenderer>().enabled = false;

        GameObject temp = (GameObject)Instantiate(deathSystem, transform.position, transform.rotation);
        Destroy(temp, 2.0f);

        ballRigidbody.useGravity = false;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.freezeRotation = true;
    }

    public bool IsDead()
    {
        if (dead)
            return true;
        return false;
    }
}