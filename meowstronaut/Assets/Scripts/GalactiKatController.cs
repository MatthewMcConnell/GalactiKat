using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalactiKatController : MonoBehaviour
{
    // a boolean flag I need to use to stop the level restarting instead of moving onto the next leve
    public bool shouldRestart = true;
    public bool onMoon = false;
    GameObject currentMoon = null;
    public float jumpForce;
    public Rigidbody2D katRigidBody;
    public FixedJoint2D fixedJoint;
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip failSound;

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
        if (shouldRestart)
        {
            StartCoroutine(PlayFailureSoundAndRestart());
        }
            
    }

    void Jump()
    {
        fixedJoint.autoConfigureConnectedAnchor = true;
        onMoon = false;
        fixedJoint.enabled = false;
        katRigidBody.velocity = (transform.position - currentMoon.transform.position) * jumpForce;

        audioSource.clip = jumpSound;
        audioSource.Play();
    }


    IEnumerator PlayFailureSoundAndRestart()
    {
        audioSource.clip = failSound;
        audioSource.Play();
        yield return new WaitForSeconds(2);
        LevelController.RestartLevel();
    }
}
