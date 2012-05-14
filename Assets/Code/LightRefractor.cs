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
        LightCollisionDetect photon;
        if (photon = collider.GetComponent<LightCollisionDetect>())
        {
            if (photon.lastCollision != this)
            {
                photon.lastCollision = this;

                Vector3 pos = this.transform.position;
                photon.transform.position = pos;
				
				float yNormal = this.transform.eulerAngles.y;
				float oldDirection = photon.transform.eulerAngles.y;
				
                photon.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, photon.transform.eulerAngles.y + refractor_angle, photon.transform.eulerAngles.z);
				
				
				float newDirection = photon.transform.eulerAngles.y;
				
				
				
				if(Mathf.Abs(Mathf.DeltaAngle(yNormal,newDirection)) > 80 || Mathf.Abs(Mathf.DeltaAngle(yNormal,oldDirection)) < 100) {
					Destroy(photon.gameObject);
				}
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
    }
}
