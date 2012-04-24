using UnityEngine;
using System.Collections;

public class LightMirror : MonoBehaviour {

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

                float yNormal = this.transform.eulerAngles.y;
                float myAngle = photon.transform.eulerAngles.y;

                float revAngle = myAngle - 180;

                float delta = yNormal - revAngle;
                float nAngle = 2 * delta + revAngle;

                photon.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, nAngle, photon.transform.eulerAngles.z);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
    }
}