using UnityEngine;
using System.Collections;

public class GridPosition : MonoBehaviour {

    public bool useTransformCoords = true;
    public int x = 0;
    public int z = 0;

	// Use this for initialization
	void Start () {
        if (useTransformCoords)
        {
            x = Mathf.RoundToInt(transform.position.x);
            z = Mathf.RoundToInt(transform.position.z);
        }
        else
        {
            transform.position = new Vector3(x, transform.position.y, z);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.RoundToInt(transform.position.x) != x || Mathf.RoundToInt(transform.position.z) != z)
        {
            transform.position = new Vector3(x, transform.position.y, z);
        }
	}
}