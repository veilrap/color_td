using UnityEngine;
using System.Collections;

public class LightCollimator : MonoBehaviour {

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

                Vector3 pos = this.transform.position;
                photon.transform.position = pos;

                float nAngle = yNormal;
                if (Mathf.Abs(Mathf.DeltaAngle(yNormal, myAngle)) > 90)
                {
                    nAngle = yNormal + 180;
                }
                photon.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, nAngle, photon.transform.eulerAngles.z);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
    }
}
