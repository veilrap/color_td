using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour {

    public int pushDistance = 2;

    public bool allowPush = true;

    bool pushing = false;
    Collision collision;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if (pushing)
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
                        if (!gridPosition.locked)
                        {

                            //Vector3 pushDirection = this.transform.localPosition - pusher.transform.localPosition;
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

                            if (!Input.GetKey("left") && !Input.GetKey("a") && xDiff < 0)
                            {
                                xDiff = 0;
                            }
                            if (!Input.GetKey("right") && !Input.GetKey("d") && xDiff > 0)
                            {
                                xDiff = 0;
                            }
                            if (!Input.GetKey("up") && !Input.GetKey("w") && zDiff > 0)
                            {
                                zDiff = 0;
                            }
                            if (!Input.GetKey("down") && !Input.GetKey("s") && zDiff < 0)
                            {
                                zDiff = 0;
                            }

                            int xTarg = gridPosition.x + xDiff;
                            int zTarg = gridPosition.z + zDiff;

                            Debug.Log("xTarg: " + xTarg);
                            Debug.Log("zTarg: " + zTarg);

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
                                    Collider otherCollider;
                                    if (otherCollider = transform.parent.GetChild(i).GetComponent<Collider>())
                                    {
                                        if (otherCollider.bounds.Contains(new Vector3(transform.position.x + xDiff, transform.position.y, transform.position.z + zDiff)))
                                            allowMove = false;
                                    }
                                }

                                if (allowMove)
                                {
                                    gridPosition.x = xTarg;
                                    gridPosition.z = zTarg;
                                    pushing = false;
                                }
                                //this.transform.position += pushVector;
                            }
                        }
                    }
                }
            }
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        this.collision = collision;
        pushing = true;
        
    }

    void OnCollisionExit(Collision collision)
    {
        pushing = false;
        this.collision = null;
    }
}
