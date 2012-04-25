using UnityEngine;
using System.Collections;

public class LightTarget : MonoBehaviour {

    public Color successColor = new Color(1, 1, 1);
    public float threshold = 0.3f;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        LaserCollisionDetect photon;
        if (photon = collider.GetComponent<LaserCollisionDetect>())
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
                    //Do Successful Hit!
                }

                Destroy(photon.gameObject);
            }
        }
    }
}
