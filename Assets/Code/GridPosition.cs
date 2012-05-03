using UnityEngine;
using System.Collections;

public class GridPosition : MonoBehaviour {

    public bool useTransformCoords = true;
    public int stepGap = 2;
    public int x = 0;
    public int z = 0;

    int roundToStepGap(float f)
    {
        float modded = f % stepGap;
        float halfGap = (float)stepGap / 2.0f;
        if (modded < halfGap)
        {
            f = f - modded;
        }
        else
        {
            f = f - modded + stepGap;
        }

        return Mathf.RoundToInt(f);
    }

	// Use this for initialization
	void Start () {
        if (useTransformCoords)
        {
            x = roundToStepGap(transform.localPosition.x);
            z = roundToStepGap(transform.localPosition.z);
        }
        transform.localPosition = new Vector3(x, transform.localPosition.y, z);
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.RoundToInt(transform.localPosition.x) != x || Mathf.RoundToInt(transform.localPosition.z) != z)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, z);
        }
	}
}
