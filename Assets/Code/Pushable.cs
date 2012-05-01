using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour {

    public int pushDistance = 2;

    public bool allowPush = true;

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        Pusher pusher;
        if (pusher = collider.GetComponent<Pusher>())
        {
            if (pusher.doPush && allowPush)
            {
                GridPosition gridPosition;
                if (gridPosition = this.GetComponent<GridPosition>())
                {
                    Vector3 pushDirection = this.transform.position - pusher.transform.position;
                    pushDirection.y = 0;
                    if (Mathf.Abs(pushDirection.x) > Mathf.Abs(pushDirection.z))
                    {
                        pushDirection.z = 0;
                    }
                    else
                    {
                        pushDirection.x = 0;
                    }

                    pushDirection = pushDirection.normalized;

                    Vector3 pushVector = pushDistance * pushDirection;

                    int xDiff = Mathf.RoundToInt(pushVector.x);
                    int zDiff = Mathf.RoundToInt(pushVector.z);

                    int xTarg = gridPosition.x + xDiff;
                    int zTarg = gridPosition.z + zDiff;

                    //((Check if Blocked))
                    if (transform.parent)
                    {
                        bool allowMove = true;
                        for (int i = 0; i < transform.parent.GetChildCount(); i++)
                        {
                            GridPosition otherPosition;
                            if (otherPosition = transform.parent.GetChild(i).GetComponent<GridPosition>())
                            {
                                if (otherPosition.x == xTarg && otherPosition.z == zTarg)
                                    allowMove = false;
                            }
                        }

                        GridPositionBounds gpb;
                        if (gpb = transform.parent.GetComponent<GridPositionBounds>())
                        {
                            if (xTarg < gpb.minX || xTarg > gpb.maxX || zTarg < gpb.minZ || zTarg > gpb.maxZ)
                            {
                                allowMove = false;
                            }
                        }
                        if (allowMove)
                        {
                            gridPosition.x = xTarg;
                            gridPosition.z = zTarg;
                        }
                        //this.transform.position += pushVector;
                    }
                }
            }
        }
    }
}
