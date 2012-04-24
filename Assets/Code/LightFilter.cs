using UnityEngine;
using System.Collections;

public class LightFilter : MonoBehaviour {

    public bool allowRed = true;
    public bool allowGreen = false;
    public bool allowBlue = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        LaserCollisionDetect photon;
        if (photon = collider.GetComponent<LaserCollisionDetect>())
        {
            if (photon.lastCollision != this)
            {
                photon.lastCollision = this;
                ParticleColor pc = photon.GetComponent<ParticleColor>();

                Vector3 pos = this.transform.position;
                photon.transform.position = pos;

                if (!allowRed)
                {
                    if(pc.color.b < 0.1 && pc.color.g < 0.1) {
                        Destroy(collider.gameObject);
                        return;
                    } else {
                        pc.color = new Color(0,pc.color.g,pc.color.b);
                    }
                }

                if (!allowBlue)
                {
                    if(pc.color.r < 0.1 && pc.color.g < 0.1) {
                        Destroy(collider.gameObject);
                        return;
                    } else {
                        pc.color = new Color(pc.color.r,pc.color.g,0);
                    }
                }

                if (!allowGreen)
                {
                    if(pc.color.r < 0.1 && pc.color.b < 0.1) {
                        Destroy(collider.gameObject);
                        return;
                    } else {
                        pc.color = new Color(pc.color.r,0,pc.color.b);
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
    }
}
