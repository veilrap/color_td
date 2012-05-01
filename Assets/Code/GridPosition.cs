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
            x = Mathf.RoundToInt(transform.localPosition.x);
            z = Mathf.RoundToInt(transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, z);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.RoundToInt(transform.localPosition.x) != x || Mathf.RoundToInt(transform.localPosition.z) != z)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, z);
        }
	}
}
