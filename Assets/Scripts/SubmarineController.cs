using UnityEngine;
using System.Collections;

public class SubmarineController : MonoBehaviour {
    public float torque;
    public GameObject controller1;
    public GameObject controller2;

    public float speed;
    public float turnRate;

	void Awake()
    {        
    }
	
	// Update is called once per frame
	void Update () {

        // Negative is up stick      
        float leftThrust = Input.GetAxis("Axis 2") * turnRate * Time.deltaTime * -1;
        float rightThrust = Input.GetAxis("Axis 5") * turnRate * Time.deltaTime * -1;
        Debug.Log("Left thrust: " + leftThrust + "   Right thrust: " + rightThrust);

        if(leftThrust > 0 && rightThrust > 0)
        {
            // Go forward
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
        else if(leftThrust < 0 && rightThrust > 0)
        {
            // turn left
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, -turnRate, 0));
        }
        else if(leftThrust > 0 && rightThrust < 0)
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, turnRate, 0));
        }
        else if(leftThrust < 0 && rightThrust <0)
        {
            // go backwards
            GetComponent<Rigidbody>().AddForce(transform.forward * -speed);
        }
        else
        {
            // recover orientation
        }
        //GetComponent<Rigidbody>().AddTorque(new Vector3(0, -h, 0));
        //transform.Rotate(0, 1, 0);

        //if (Input.GetKey(KeyCode.D) || (Input.GetAxis("Axis 2") < 0 && Input.GetAxis("Axis 5") > 0))
        //{
        //    transform.Rotate(0, .5f, 0);
        //}

        if (Input.GetAxis("Axis 1") < 0 && Input.GetAxis("Axis 4") < 0)
        {
            GetComponent<Rigidbody>().AddForce(transform.right * -speed);
        }

        if (Input.GetAxis("Axis 1") > 0 && Input.GetAxis("Axis 4") > 0)
        {
            GetComponent<Rigidbody>().AddForce(transform.right * speed);
        }
    }
}
