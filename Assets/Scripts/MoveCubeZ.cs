using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeZ : MonoBehaviour
{
    float moveSpeed = 8.0f;
    bool isForward = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 25.0f && isForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        else if (transform.position.z > 1.0f && !isForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -moveSpeed);
        }

        else
        {
            isForward = !isForward;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.parent = gameObject.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
