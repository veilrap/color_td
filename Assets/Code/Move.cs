using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float speedX = 0;
    public float speedY = 0;
    public float speedZ = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float sinceUpdate = Time.deltaTime;
        Vector3 moveSpeed = new Vector3(sinceUpdate * speedX, sinceUpdate * speedY, sinceUpdate * speedZ);
        this.transform.Translate(moveSpeed);
	}
}
