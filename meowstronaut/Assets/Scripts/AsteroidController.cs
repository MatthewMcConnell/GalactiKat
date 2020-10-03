using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    public int minAsteroidSpeed;
    public int maxAsteroidSpeed;
    Vector3 originalPosition;
    Quaternion originalRotation;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        Reset();
        AddRandomForce();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            Reset();
            AddRandomForce();
        }
    }

    void Reset()
    {
        transform.SetPositionAndRotation(originalPosition, originalRotation);
        transform.Rotate(0, 0, Random.Range(-10, 10));
    }

    void AddRandomForce()
    {
        rigidBody.AddForce(transform.up * Random.Range(minAsteroidSpeed, maxAsteroidSpeed));
    }
}
