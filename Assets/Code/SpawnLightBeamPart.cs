using UnityEngine;
using System.Collections;

public class SpawnLightBeamPart : MonoBehaviour {

    public GameObject LaserBeamPart;
    public float coolDown = 0.05f;
    public float countUp = 0f;

    public Color lightColor = new Color(1, 1, 1);

    public bool spawnEnabled = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnEnabled)
        {
            countUp += Time.deltaTime;
            if (countUp > coolDown)
            {
                GameObject go = (GameObject)Instantiate(LaserBeamPart, this.transform.position, Quaternion.identity);
                go.transform.parent = this.transform;
                //go.transform.Rotate(new Vector3(90, 0, 0));
                go.transform.rotation = go.transform.parent.rotation;
                go.GetComponent<ParticleColor>().color = lightColor;
                countUp -= coolDown;
                go.transform.position += new Vector3(0, 0.1f, 0);
                go.transform.Translate(new Vector3(0, 0, 1f));
            }
        }
	}
}
