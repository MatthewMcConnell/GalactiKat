using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonController : MonoBehaviour
{

    public float rotationSpeed;
    public Rigidbody2D moonRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        moonRigidBody.AddTorque(rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
