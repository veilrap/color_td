using UnityEngine;
using System.Collections;

public class LightTarget : MonoBehaviour {

    public Color successColor = new Color(1, 1, 1);
    
    public float threshold = 0.3f;

    public bool successful = false;
    public float countDown = 0.25f;
    float currentCount = 0.0f;

    public float currentRed = 0.0f;
    public float currentGreen = 0.0f;
    public float currentBlue = 0.0f;

    public float redCount = 0.0f;
    public float greenCount = 0.0f;
    public float blueCount = 0.0f;

    public bool allowPassThru = false;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        float deltaR = Mathf.Abs(currentRed - successColor.r);
        float deltaG = Mathf.Abs(currentGreen - successColor.g);
        float deltaB = Mathf.Abs(currentBlue - successColor.b);
        float totalDelta = deltaR + deltaG + deltaB;

        if (totalDelta < 0.3f)
        {
            successful = true;
        }
        else
        {
            successful = false;
        }

        redCount -= Time.deltaTime;
        greenCount -= Time.deltaTime;
        blueCount -= Time.deltaTime;

        if (redCount < 0)
            currentRed = 0;
        if (greenCount < 0)
            currentGreen = 0;
        if (blueCount < 0)
            currentBlue = 0;
        
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

                if (pc.color.r > 0.1)
                {
                    currentRed = pc.color.r;
                    redCount = countDown;
                }
                if (pc.color.g > 0.1)
                {
                    currentGreen = pc.color.g;
                    greenCount = countDown;
                }
                if (pc.color.b > 0.1)
                {
                    currentBlue = pc.color.b;
                    blueCount = countDown;
                }

                if(!allowPassThru) 
                    Destroy(photon.gameObject);
            }
        }
    }
}
