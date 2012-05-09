using UnityEngine;
using System.Collections;

public class LightFilter : MonoBehaviour {

    public Color allowedColors = new Color(1, 0, 1);
    public bool dontTint = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!dontTint)
            this.renderer.material.color = allowedColors;
    }

    void OnTriggerEnter(Collider collider)
    {
        LightCollisionDetect photon;
        if (photon = collider.GetComponent<LightCollisionDetect>())
        {
            if (photon.lastCollision != this)
            {
                photon.lastCollision = this;

                ParticleColor pc = photon.GetComponent<ParticleColor>();

                bool allowRed = (allowedColors.r > 0.5f);
                bool allowGreen = (allowedColors.g > 0.5f);
                bool allowBlue = (allowedColors.b > 0.5f);

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
