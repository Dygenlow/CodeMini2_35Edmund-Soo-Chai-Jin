using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController35 : MonoBehaviour
{
    float moveSpeed = 8.0f;
    float jumpForce = 12.0f;
    float gravityModifier = 2.5f;
    float absZ;

    bool onStartCube = true;
    bool onMoveCube = false;
    bool onCube = true;

    Rigidbody playerRb;
    Vector3 startPos;

    bool isGround = true;

    public GameObject movingCube;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && !onMoveCube && onStartCube && onCube)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            onCube = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onMoveCube && !onStartCube && onCube)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            onCube = false;
        }

        if (onMoveCube && onCube)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, movingCube.transform.position.z);
        }

        if (onStartCube && onCube)
        {
            transform.position = startPos;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("StartCube"))
        {
            onStartCube = true;
            onMoveCube = false;
            onCube = true;

            startPos = transform.position;
        }

        if(collision.gameObject.CompareTag("MoveCube"))
        {
            onStartCube = false;
            onMoveCube = true;
            onCube = true;

            float playerZ = transform.position.z;
            float cubeZ = movingCube.transform.position.z;

            absZ = cubeZ - playerZ;
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
