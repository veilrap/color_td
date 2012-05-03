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
                    door.lockedOpen = true;
					//Destroy(door.gameObject);
				}
                
				SpawnLightBeamPart spawner;
				if(spawner = child.GetComponent<SpawnLightBeamPart>()) {
					spawner.spawnEnabled = false;
                    ParticleColor pc;
                    for (int j = 0; j < child.GetChildCount(); j++)
                    {
                        if (pc = spawner.transform.GetChild(j).GetComponent<ParticleColor>())
                        {
                            Destroy(pc.gameObject);
                        }
                    }
				}
			}
			
			if(nextLevel) {
				//chameleon.transform.parent = nextLevel.transform;
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
