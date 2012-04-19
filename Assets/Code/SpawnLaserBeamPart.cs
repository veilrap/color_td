using UnityEngine;
using System.Collections;

public class SpawnLaserBeamPart : MonoBehaviour {

    public GameObject LaserBeamPart;
    public float coolDown = 0.05f;
    public float countUp = 0f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        countUp += Time.deltaTime;
        if(countUp > coolDown) {
            GameObject go = (GameObject)Instantiate(LaserBeamPart, this.transform.position, Quaternion.identity);
            go.transform.parent = this.transform;
            go.transform.Rotate(new Vector3(90, 0, 0));
            countUp -= coolDown;
        }
	}
}
