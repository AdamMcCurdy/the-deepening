using UnityEngine;
using System.Collections;

public class SubmarineController : MonoBehaviour {
    public float torque;
    //public Rigidbody rb;
	// Use this for initialization
	void Start () {
        //rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) || (Input.GetAxis("Axis 2") < 0 && Input.GetAxis("Axis 5") < 0))
        {
            //transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * .5f, Time.deltaTime * 5f);
            GetComponent<Rigidbody>().AddForce(transform.forward * .5f);
        }

        if (Input.GetKey(KeyCode.S) || (Input.GetAxis("Axis 2") > 0 && Input.GetAxis("Axis 5") > 0))
        {
            //transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * -.5f, Time.deltaTime * 5f);
            GetComponent<Rigidbody>().AddForce(transform.forward * -.5f);
        }

        //if (Input.GetKey(KeyCode.A) || (Input.GetAxis("Axis 2") > 0 && Input.GetAxis("Axis 5") < 0))
        //{
        float h = Input.GetAxis("Axis 2") * 10f * Time.deltaTime;
        GetComponent<Rigidbody>().AddTorque(transform.up * -h);
        //}

        //if (Input.GetKey(KeyCode.D) || (Input.GetAxis("Axis 2") < 0 && Input.GetAxis("Axis 5") > 0))
        //{
        //    transform.Rotate(0, .5f, 0);
        //}

        if (Input.GetAxis("Axis 1") < 0 && Input.GetAxis("Axis 4") < 0)
        {
            GetComponent<Rigidbody>().AddForce(transform.right * -.5f);
        }

        if (Input.GetAxis("Axis 1") > 0 && Input.GetAxis("Axis 4") > 0)
        {
            GetComponent<Rigidbody>().AddForce(transform.right * .5f);
        }
    }
}
