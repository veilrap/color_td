using UnityEngine;
using System.Collections;

public class LightOneWayMirror : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

    void OnTriggerEnter(Collider collider)
    {
        LightCollisionDetect photon;
        if (photon = collider.GetComponent<LightCollisionDetect>())
        {
            if (photon.lastCollision != this)
            {
                photon.lastCollision = this;

                Vector3 pos = this.transform.position;
                photon.transform.position = pos;

                float yNormal = this.transform.eulerAngles.y;
                float myAngle = photon.transform.eulerAngles.y;

                if (Mathf.Abs(Mathf.DeltaAngle(yNormal, myAngle)) > 90)
                {
                    float revAngle = myAngle - 180;

                    float delta = yNormal - revAngle;
                    float nAngle = 2 * delta + revAngle;


                    photon.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, nAngle, photon.transform.eulerAngles.z);
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
    }
}
