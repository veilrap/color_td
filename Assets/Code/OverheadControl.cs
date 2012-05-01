using UnityEngine;
using System.Collections;

public class OverheadControl : MonoBehaviour {

    public float moveSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis != 0 || vAxis != 0)
        {
            float timeDelta = Time.deltaTime;

            Vector3 movement = new Vector3(hAxis * moveSpeed * timeDelta, 0, vAxis * moveSpeed * timeDelta);
            this.transform.position += movement;
        }
	}
}
