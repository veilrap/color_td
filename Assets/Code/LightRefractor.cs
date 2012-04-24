using UnityEngine;
using System.Collections;

public class LightRefractor : MonoBehaviour {

    public float refractor_angle = 45f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

    void OnTriggerEnter(Collider collider)
    {
        LaserCollisionDetect photon;
        if (photon = collider.GetComponent<LaserCollisionDetect>())
        {
            if (photon.lastCollision != this)
            {
                photon.lastCollision = this;

                Vector3 pos = this.transform.position;
                photon.transform.position = pos;

                photon.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, photon.transform.eulerAngles.y + refractor_angle, photon.transform.eulerAngles.z);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
    }
}
