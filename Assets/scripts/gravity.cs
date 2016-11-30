using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {
    public GameObject gravityPoint;
    public float gravityStrength = 1.0f;
    public bool gravityEnabled = false;
	// Use this for initialization
	void Start () {
        gravityPoint = GameObject.Find("gravityPoint");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gravityEnabled = !gravityEnabled;

			if (gravityEnabled) {
				Debug.Log ("Gravity enabled");
			} else {
				Debug.Log ("Gravity disabled");
			}
        }
	}

    void FixedUpdate()
    {
        if (gravityEnabled) { 
        Vector3 gravityDir = gravityPoint.transform.position - gameObject.transform.position;
        gameObject.GetComponent<Rigidbody>().AddForce(gravityDir* gravityStrength);
        }
    }
}
