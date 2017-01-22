using UnityEngine;
using System.Collections;

public class SubmarineController : MonoBehaviour {
    public float torque;

    public GameObject controller1;
    public GameObject controller2;


    GameObject[] controllers = new GameObject[2];

    public float speed;
    public float turnRate;
    public float neutralZone;

	void Awake()
    {
        controllers[0] = controller1;
        controllers[1] = controller2;
    }
	
	// Update is called once per frame
	void Update () {
        if(controller1.GetComponent<ViveControllerInput>().side == "left")
        {
            Debug.Log("On Left");
            controllers[0] = controller1;
            controllers[1] = controller2;
        }
        else
        {         
            Debug.Log("On Right");
            controllers[0] = controller2;
            controllers[1] = controller1;
        }

        // Controllers
        // Negative is up stick      
        //float leftThrust = Input.GetAxis("Axis 2") * turnRate * Time.deltaTime * -1;
        //float rightThrust = Input.GetAxis("Axis 5") * turnRate * Time.deltaTime * -1;

        // SteamVR controllers
        float leftThrust = controllers[0].transform.rotation.eulerAngles.x * turnRate * Time.deltaTime;
        float rightThrust = controllers[1].transform.rotation.eulerAngles.x * turnRate * Time.deltaTime;

        if (leftThrust > neutralZone && rightThrust > neutralZone)
        {
            // Go forward
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
        else if(leftThrust < neutralZone && rightThrust > neutralZone)
        {
            // turn left
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, -turnRate, 0));
        }
        else if(leftThrust > neutralZone && rightThrust < neutralZone)
        {
            GetComponent<Rigidbody>().AddTorque(new Vector3(0, turnRate, 0));
        }
        else if(leftThrust < neutralZone && rightThrust < neutralZone)
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
