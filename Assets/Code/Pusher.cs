using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {

    public bool doPush = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            doPush = true;
        }
        else
        {
            //doPush = false;
        }
	}
}
