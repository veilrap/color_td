using UnityEngine;
using System.Collections;

public class GridPosition : MonoBehaviour {

    public bool useTransformCoords = true;
    public int stepGap = 2;
    public int x = 0;
    public int z = 0;

    int original_x;
    int original_z;

    int roundToStepGap(float f)
    {
        if (f == 0.0f)
            return 0;
        float sign = 1;
        if (f < 0)
            sign = -1;

        float modded = Mathf.Abs(f) % stepGap;
        float halfGap = (float)stepGap / 2.0f;
        if (modded < halfGap)
        {
            f = Mathf.Abs(f) - modded;
        }
        else
        {
            f = Mathf.Abs(f) - modded + stepGap;
        }

        return Mathf.RoundToInt(f*sign);
    }

	// Use this for initialization
	void Start () {
        if (useTransformCoords)
        {
            x = roundToStepGap(transform.localPosition.x);
            z = roundToStepGap(transform.localPosition.z);
        }
        transform.localPosition = new Vector3(x, transform.localPosition.y, z);

        original_x = x;
        original_z = z;
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.RoundToInt(transform.localPosition.x) != x || Mathf.RoundToInt(transform.localPosition.z) != z)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, z);
        }
        if (Input.GetButtonDown("Reset"))
        {
            x = original_x;
            z = original_z;
        }
	}

    public bool locked = false;
    void OnMouseDown()
    {
        Debug.Log(gameObject);
        locked = !locked;

        if (this.transform.FindChild("Lock"))
        {
            this.transform.FindChild("Lock").renderer.enabled = locked;
        }
    }
}
