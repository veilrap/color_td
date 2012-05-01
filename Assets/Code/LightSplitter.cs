using UnityEngine;
using System.Collections;

public class LightSplitter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider collider)
    {
        LightCollisionDetect photon;
        if (photon = collider.GetComponent<LightCollisionDetect>())
        {
            if (photon.lastCollision != this)
            {
                photon.lastCollision = this;

                Transform parent = photon.transform.parent;
                Color originalColor = photon.GetComponent<ParticleColor>().color;

                Vector3 pos = this.transform.position;
                photon.transform.position = pos;

                photon.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x,photon.transform.eulerAngles.y+90,photon.transform.eulerAngles.z);
				
				GameObject blueLight = (GameObject)Instantiate(photon.gameObject);
                blueLight.transform.parent = parent;
                blueLight.transform.position = photon.transform.position;
                blueLight.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x,photon.transform.eulerAngles.y+180,photon.transform.eulerAngles.z);

                blueLight.GetComponent<LightCollisionDetect>().lastCollision = this;
            }
        }
	}
}
