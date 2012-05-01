using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	
	public GameObject nextLevel = null;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter(Collision collision) {
		OverheadControl chameleon;
		if(chameleon = collision.collider.GetComponent<OverheadControl>()) {
			for(int i=0;i<transform.parent.GetChildCount();i++) {
				Transform child = transform.parent.GetChild(i);
				Door door;
				if(door = child.GetComponent<Door>()) {
					Destroy(door.gameObject);
				}
				SpawnLightBeamPart spawner;
				if(spawner = child.GetComponent<SpawnLightBeamPart>()) {
					spawner.spawnEnabled = false;
				}
			}
			
			if(nextLevel) {
				chameleon.transform.parent = nextLevel.transform;
				for(int i=0;i<nextLevel.transform.GetChildCount();i++) {
				Transform child = nextLevel.transform.GetChild(i);
				SpawnLightBeamPart spawner;
				if(spawner = child.GetComponent<SpawnLightBeamPart>()) {
					spawner.spawnEnabled = true;
				}
			}
			}
		}
		Destroy (this.gameObject);
	}
}
