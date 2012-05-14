using UnityEngine;
using System.Collections;

public class ParticleColor : MonoBehaviour {

    public Color color = new Color(1, 1, 1);

	// Use this for initialization
	void Start () {
        this.light.color = color;
	}
	
	// Update is called once per frame
	void Update () {
        this.light.color = color;

        if (Input.GetButtonDown("Reset"))
        {
            Destroy(this.gameObject);
        }
	}
}
