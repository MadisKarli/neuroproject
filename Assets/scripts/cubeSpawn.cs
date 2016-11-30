using UnityEngine;
using System.Collections;

public class cubeSpawn : MonoBehaviour {
    [SerializeField] public GameObject cube;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(cube, this.transform);
        }
	}
}
