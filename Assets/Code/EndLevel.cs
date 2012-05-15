using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	
	public GameObject nextLevel = null;
    public AudioClip clip = null;

    public bool alreadyTriggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter(Collision collision) {
        if (!alreadyTriggered)
        {
            OverheadControl chameleon;
            if (chameleon = collision.collider.GetComponent<OverheadControl>())
            {
                for (int i = 0; i < transform.parent.GetChildCount(); i++)
                {
                    Transform child = transform.parent.GetChild(i);
                    Door door;
                    if (door = child.GetComponent<Door>())
                    {
                        door.lockedOpen = true;
                        //Destroy(door.gameObject);
                    }

                    SpawnLightBeamPart spawner;
                    if (spawner = child.GetComponent<SpawnLightBeamPart>())
                    {
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

                    LightTarget target;
                    if (target = child.GetComponent<LightTarget>())
                    {
                        target.finished = true;
                    }
                }

                if (nextLevel)
                {
                    //chameleon.transform.parent = nextLevel.transform;
                    for (int i = 0; i < nextLevel.transform.GetChildCount(); i++)
                    {
                        Transform child = nextLevel.transform.GetChild(i);
                        SpawnLightBeamPart spawner;
                        if (spawner = child.GetComponent<SpawnLightBeamPart>())
                        {
                            spawner.spawnEnabled = true;
                        }
                    }
                }

                if (clip != null)
                {
                    chameleon.audio.clip = clip;
                    chameleon.audio.Play();
                    lightenUp = true;
                }
            }
            alreadyTriggered = true;
            collider.enabled = false;
        }
	}

    bool lightenUp = false;
    int currentColor = 0;
    float changeTime = 0;
    float targetTime = 3;
    Color originalColor = new Color(.4f, .4f, .4f);
    Color targetColor = new Color(1, 1, 1);
    void Update()
   {
        

        if (lightenUp)
        {
            changeTime += Time.deltaTime;
            float percent = Mathf.Clamp01(changeTime / targetTime);
            RenderSettings.ambientLight = Color.Lerp(originalColor, targetColor, percent);

            if (percent >= .99)
            {
                GameObject.Find("victorysplash").guiTexture.enabled = true;
            }
        }
        else
        {
            
        }
    }
}
