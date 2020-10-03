using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalactiKatController : MonoBehaviour
{
    public bool onMoon = false;
    GameObject currentMoon = null;
    public float jumpForce;
    public Rigidbody2D katRigidBody;
    public FixedJoint2D fixedJoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Jumps on Space
        if (Input.GetKeyDown(KeyCode.Space) && onMoon)
            Jump();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // If hit by a moon then land on it
        if (other.gameObject.tag == "Moon" && other.gameObject != currentMoon) 
        {
            onMoon = true;
            fixedJoint.enabled = true;
            fixedJoint.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
            currentMoon = other.gameObject;
            fixedJoint.autoConfigureConnectedAnchor = false;
            
        }
    }

    void OnBecameInvisible()
    {
        LevelController.RestartLevel();
    }

    void Jump()
    {
        fixedJoint.autoConfigureConnectedAnchor = true;
        onMoon = false;
        fixedJoint.enabled = false;
        katRigidBody.velocity = (transform.position - currentMoon.transform.position) * jumpForce;
    }
}
