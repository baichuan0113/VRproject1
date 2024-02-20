using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject world;
    private Rigidbody rb;
    private float speed = 3f;
    private float forceMagnitude = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        world = GameObject.Find("World");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            rb.velocity = gameObject.transform.forward * speed;
        }

        Vector3 toCenterDir = (world.transform.position - gameObject.transform.position).normalized;
        Vector3 toBodyDir = (gameObject.transform.position - world.transform.position).normalized;
        rb.AddForce(forceMagnitude * toCenterDir);

        // update the objects rotation in relation to the planet
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, toBodyDir) * transform.rotation;
        // smooth rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50 * Time.fixedDeltaTime);

    }
}
