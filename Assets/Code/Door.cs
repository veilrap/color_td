using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public LightTarget triggeringTarget;

    public Vector3 initialPostion;
    public Vector3 openOffset = new Vector3(0, 0, 2);

    bool opened = false;

	// Use this for initialization
	void Start () {
        initialPostion = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (triggeringTarget)
        {
            if (triggeringTarget.successful && !opened)
            {
                opened = true;
                transform.position += openOffset;
            }
            if (!triggeringTarget.successful && opened)
            {
                opened = false;
                transform.position -= openOffset;
            }
        }
	}
}
