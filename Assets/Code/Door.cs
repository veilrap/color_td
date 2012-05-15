using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public Vector3 initialPostion;
    public Vector3 openOffset = new Vector3(0, 0, 2);

    bool opened = false;
    public bool lockedOpen = false;

	// Use this for initialization
	void Start () {
        initialPostion = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        bool allTargets = true;
        for (int i = 0; i < transform.parent.GetChildCount(); i++)
        {
            Transform child = transform.parent.GetChild(i);
            
            if (child.GetComponent<LightTarget>())
            {
                if (!child.GetComponent<LightTarget>().successful)
                    allTargets = false;
            }

            
        }

        if (allTargets && !opened || lockedOpen)
        {
            opened = true;

            collider.enabled = false;
            renderer.enabled = false;
			
			this.audio.Play();
			
            //transform.position += openOffset;
        }
        if (!allTargets && opened && !lockedOpen)
        {
            opened = false;

            collider.enabled = true;
            renderer.enabled = true;
            //transform.position -= openOffset;
        }
	}
}
