using UnityEngine;
using System.Collections;

public class LaserCollisionDetect : MonoBehaviour {

    public bool allowCollision = true;
    public GameObject LaserBeamPart;

    public GameObject lastSpawned;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //if (!this.renderer.isVisible)
        //    Destroy(this.gameObject);
	}

    void OnTriggerEnter(Collider collider)
    {
        if (allowCollision)
        {
            allowCollision = false;
            if (collider.name == "MobTest")
            {
                Destroy(this.gameObject);
            }
            if (collider.name == "Mirror")
            {
                float yNormal = collider.transform.eulerAngles.y;
                float myAngle = this.transform.eulerAngles.y;

                float revAngle = myAngle - 180;

                float delta = yNormal - revAngle;
                float nAngle = 2 * delta + revAngle;

                this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, nAngle, this.transform.eulerAngles.z);
            }
            if (collider.name == "Prisim")
            {
                Transform parent = this.transform.parent;
                this.GetComponent<ParticleColor>().color = new Color(1,0,0);

                Vector3 pos = collider.transform.position;
                this.transform.position = pos;

                //Green Light
                GameObject greenLight = (GameObject)Instantiate(this.gameObject);
                greenLight.transform.parent = parent;
                greenLight.transform.position = this.transform.position;
                greenLight.transform.rotation = this.transform.rotation;

                greenLight.GetComponent<LaserCollisionDetect>().allowCollision = false;

                greenLight.GetComponent<ParticleColor>().color = new Color(0, 1, 0);

                greenLight.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 45, transform.eulerAngles.z);

                //Blue Light
                GameObject blueLight = (GameObject)Instantiate(this.gameObject);
                blueLight.transform.parent = parent;
                blueLight.transform.position = this.transform.position;
                blueLight.transform.rotation = this.transform.rotation;

                blueLight.GetComponent<LaserCollisionDetect>().allowCollision = false;

                blueLight.GetComponent<ParticleColor>().color = new Color(0, 0, 1);

                blueLight.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        allowCollision = true;
    }
}
