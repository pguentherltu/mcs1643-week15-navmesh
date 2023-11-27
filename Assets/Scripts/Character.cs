using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float jumpForce = 8.0f;
    public float moveSpeed = 3.0f;
    public float degreeTurnPerSecond = 90.0f;
    public GameObject groundCheckLocation;
    private Rigidbody rb;
    //private Vector3 targetAngle;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && onGround)
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            Vector3 jumpVector = transform.forward * .2f + transform.up;
            Debug.Log(jumpVector);
            rb.AddForce(jumpVector * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            //gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            gameObject.transform.position -= transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            gameObject.transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            //gameObject.transform.position += transform.forward * moveSpeed * Time.deltaTime;
            gameObject.transform.position += transform.right * moveSpeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.A))
        {
            //gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
            //gameObject.transform.position += transform.forward * moveSpeed * Time.deltaTime;
            gameObject.transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.eulerAngles += new Vector3(
                0, degreeTurnPerSecond * Time.deltaTime, 0);

            // to do 90 degree turns:
            // targetAngle = gameObject.transform.eulerAngles + new Vector3(0, 90, 0);
            // gameObject.transform.eulerAngles += new Vector3(
            //     0, degreeTurnPerSecond* Time.deltaTime, 0);


        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.eulerAngles -= new Vector3(
                0, degreeTurnPerSecond * Time.deltaTime, 0);
        }

        //if (Math.Abs(gameObject.transform.eulerAngles - targetAngle) > someNewPrecisionVariable) {
        // keep turning in the desired direction
        // if the targetAngle > current angle, +=
        // else -=
    }

    private bool IsOnGround()
    {
        return Physics.CheckSphere(groundCheckLocation.transform.position, .001f);
        
        //if(Physics.CheckSphere(groundCheckLocation.transform.position, .001f))
        //{
        //    return true;
        //}
        //return false;
    }

}

