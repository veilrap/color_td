using UnityEngine;
using System.Collections;

public class LaserCollisionDetect : MonoBehaviour {

    public bool allowCollision = true;
    public GameObject LaserBeamPart;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this.transform.position.x > 20 || this.transform.position.x < -20 || this.transform.position.z > 20 || this.transform.position.z < -20)
        {
                Destroy(this.gameObject);
        }
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
            if (collider.name == "OneWayMirror")
            {
                float yNormal = collider.transform.eulerAngles.y;
                float myAngle = this.transform.eulerAngles.y;

                if (Mathf.Abs(Mathf.DeltaAngle(yNormal, myAngle)) > 90)
                {
                    float revAngle = myAngle - 180;

                    float delta = yNormal - revAngle;
                    float nAngle = 2 * delta + revAngle;


                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, nAngle, this.transform.eulerAngles.z);
                }
            }
            if (collider.name == "Collimator")
            {
                float yNormal = collider.transform.eulerAngles.y;

                float myAngle = this.transform.eulerAngles.y;

                if (Mathf.Abs(Mathf.DeltaAngle(yNormal, myAngle)) <= 90)
                {

                    float nAngle = yNormal;

                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, nAngle, this.transform.eulerAngles.z);

                    Vector3 pos = collider.transform.position;
                    this.transform.position = pos;
                }
                else
                {
                    float nAngle = yNormal + 180;

                    this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, nAngle, this.transform.eulerAngles.z);

                    Vector3 pos = collider.transform.position;
                    this.transform.position = pos;
                }
            }
            if (collider.name == "Prisim")
            {
                Transform parent = this.transform.parent;
                Color originalColor = this.GetComponent<ParticleColor>().color;

                Vector3 pos = collider.transform.position;
                this.transform.position = pos;

                //Green Light
                if (originalColor.g > 0.9)
                {
                    
                    GameObject greenLight = (GameObject)Instantiate(this.gameObject);
                    greenLight.transform.parent = parent;
                    greenLight.transform.position = this.transform.position;
                    greenLight.transform.rotation = this.transform.rotation;

                    greenLight.GetComponent<LaserCollisionDetect>().allowCollision = false;

                    greenLight.GetComponent<ParticleColor>().color = new Color(0, 1, 0);

                    greenLight.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 45, transform.eulerAngles.z);
                }

                //Blue Light
                if (originalColor.b > 0.9)
                {
                    
                    GameObject blueLight = (GameObject)Instantiate(this.gameObject);
                    blueLight.transform.parent = parent;
                    blueLight.transform.position = this.transform.position;
                    blueLight.transform.rotation = this.transform.rotation;

                    blueLight.GetComponent<LaserCollisionDetect>().allowCollision = false;

                    blueLight.GetComponent<ParticleColor>().color = new Color(0, 0, 1);

                    blueLight.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
                }

                //Red Light
                if (originalColor.r > 0.9)
                {

                    this.GetComponent<ParticleColor>().color = new Color(1, 0, 0);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        allowCollision = true;
    }
}
