using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] GameObject meshDino;
    [SerializeField] float motorTor;
    [SerializeField] float maxSpeed;
    private float rotateAngle;
    private Rigidbody rb;
    public WheelCollider dinoWheel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //calculate angle
        rotateAngle = meshDino.transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        /*/
        //calculate angle
        if (!getDirection)
        {
            //calculate angle
            targetDir = target.position - transform.position;
            //float angle = Vector3.Angle(targetDir, transform.forward);
            getDirection = true;
        }
        /*/

        //move forward world space
        // Move our position a step closer to the target.
        //transform.position = Vector3.MoveTowards(transform.position, targetDir, moveSpeed * Time.deltaTime);

        //transform.LookAt(targetDir);
        //move forward local space
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //transform.LookAt(target);

        //rotate
        if (Input.GetMouseButton(0))
        {
            meshDino.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        //stop rotate , get new direction
        if (Input.GetMouseButtonUp(0))
        {
            //rotate wheel
            rotateAngle = meshDino.transform.eulerAngles.y;
            dinoWheel.steerAngle = rotateAngle;
        }
    }
    private void FixedUpdate()
    {

        dinoWheel.motorTorque = motorTor;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        //move local
        //rb.MovePosition(transform.position + directionAngle * Time.fixedDeltaTime*moveSpeed);

        //move direction
        //rb.MovePosition(transform.position + targetDir * Time.fixedDeltaTime * moveSpeed);
        /*/
        if (getDirection)
        {
            //add force
            //rb.AddForce(targetDir* Time.fixedDeltaTime* pushSpeed, ForceMode.Impulse);

            //get direction
            targetDir = target.position - transform.position;
            getDirection = false;
        }
        /*/
    }
}
