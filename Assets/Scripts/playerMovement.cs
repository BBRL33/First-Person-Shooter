using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public Vector3 moveDirection;
    public float yRot;
    public float rotSpeed;
    public Rigidbody rb;
    public float jumpForce;
    public bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Jump();
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = (transform.forward * vertical) + (transform.right * horizontal);
        Vector3 force = moveDirection * speed * Time.deltaTime;
        transform.position += force;
    }

    public void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        yRot = mouseX * rotSpeed * Time.deltaTime;
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += yRot;
        transform.rotation = Quaternion.Euler(playerRotation);
    }

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumping = false;
    }
}
