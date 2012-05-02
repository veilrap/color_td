using UnityEngine;
using System.Collections;

public class LightPrisim : MonoBehaviour {

    public bool flipPrisimHorizontally = false;

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

                Transform parent = photon.transform.parent;
                Color originalColor = photon.GetComponent<ParticleColor>().color;

                Vector3 pos = this.transform.position;
                photon.transform.position = pos;

                //Green Light
                if (originalColor.g > 0.9)
                {

                    GameObject greenLight = (GameObject)Instantiate(photon.gameObject);
                    greenLight.transform.parent = parent;
                    greenLight.transform.position = photon.transform.position;
                    greenLight.transform.rotation = photon.transform.rotation;

                    greenLight.GetComponent<LightCollisionDetect>().lastCollision = this;

                    greenLight.GetComponent<ParticleColor>().color = new Color(0, 1, 0);

                    if (flipPrisimHorizontally)
                    {
                        greenLight.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, photon.transform.eulerAngles.y + 45, photon.transform.eulerAngles.z);
                    }
                    else
                    {
                        greenLight.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, photon.transform.eulerAngles.y - 45, photon.transform.eulerAngles.z);
                    }
                }

                //Blue Light
                if (originalColor.b > 0.9)
                {

                    GameObject blueLight = (GameObject)Instantiate(photon.gameObject);
                    blueLight.transform.parent = parent;
                    blueLight.transform.position = photon.transform.position;
                    blueLight.transform.rotation = photon.transform.rotation;

                    blueLight.GetComponent<LightCollisionDetect>().lastCollision = this;

                    blueLight.GetComponent<ParticleColor>().color = new Color(0, 0, 1);

                    if (flipPrisimHorizontally)
                    {
                        blueLight.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, photon.transform.eulerAngles.y + 90, photon.transform.eulerAngles.z);
                    }
                    else
                    {
                        blueLight.transform.eulerAngles = new Vector3(photon.transform.eulerAngles.x, photon.transform.eulerAngles.y - 90, photon.transform.eulerAngles.z);
                    }
                }

                //Red Light
                if (originalColor.r > 0.9)
                {

                    photon.GetComponent<ParticleColor>().color = new Color(1, 0, 0);
                }
                else
                {
                    Destroy(photon.gameObject);
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
    }
}
