using UnityEngine;
using System.Collections;

public class LaserCollisionDetect : MonoBehaviour {

    public MonoBehaviour lastCollision = null;

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
        
    }

    void OnTriggerExit(Collider collider)
    {
        
    }
}
