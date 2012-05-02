using UnityEngine;
using System.Collections;

public class LightTarget : MonoBehaviour {

    public Color successColor = new Color(1, 1, 1);
    public float threshold = 0.3f;

    public bool successful = false;
    public float countDown = 0.25f;
    float currentCount = 0.0f;

    public bool allowPassThru = false;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (currentCount > 0)
        {
            currentCount -= Time.deltaTime;
        }
        else
        {
            successful = false;
        }
        this.renderer.material.color = successColor;
    }

    void OnTriggerEnter(Collider collider)
    {
        LightCollisionDetect photon;
        if (photon = collider.GetComponent<LightCollisionDetect>())
        {
            if (photon.lastCollision != this)
            {
                photon.lastCollision = this;

                Vector3 pos = this.transform.position;
                photon.transform.position = pos;

                ParticleColor pc = photon.GetComponent<ParticleColor>();

                float deltaR = Mathf.Abs(pc.color.r - successColor.r);
                float deltaG = Mathf.Abs(pc.color.g - successColor.g);
                float deltaB = Mathf.Abs(pc.color.b - successColor.b);
                float totalDelta = deltaR + deltaG + deltaB;

                if (totalDelta < 0.3f)
                {
                    successful = true;
                    currentCount = countDown;
                }

                if(!allowPassThru) 
                    Destroy(photon.gameObject);
            }
        }
    }
}
