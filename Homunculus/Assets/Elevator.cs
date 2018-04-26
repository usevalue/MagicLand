using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MagicSensitive {

    public float x1;
    public float y1;
    public float z1;
    public float x2;
    public float y2;
    public float z2;
    public float speed = 1;
    public string[] from1to2;
    public bool requiresAll = false;
    Vector3 point1;
    Vector3 point2;
    

	void Start () {
        point1 = new Vector3(x1,y1,z1);
        point2 = new Vector3(x2,y2,z2);
        currentLocation = GetComponent<Transform>().position;
	}

    Vector3 currentLocation;
    Vector3 goal;
    bool changed = false;
    bool moving = false;

	void Update () {
		if(changed)
        {
            goal = getGoal();
            if (goal.Equals(currentLocation))
            {
                changed = false;
            }
            else
            {
                moving = true;
                changed = false;
            }
        }
        if(moving)
        {
            Vector3 span = goal - currentLocation;
            if(speed>=span.magnitude)
            {
                currentLocation = goal;
                moving = false;
            }
            else
            {
                currentLocation += span.normalized * speed;
            }
            GetComponent<Transform>().position = currentLocation;
        }
	}

    Vector3 getGoal()
    {
        Vector3 g;
        if (requiresAll) {
            g = point2;
            foreach(string s in from1to2)
            {
                if (!GameObject.Find(s).GetComponent<MagicObelisk>().activated)
                {
                    g = point1;
                    return g;
                }
            }
            return g;
        }
        else
        {
            g = point1;
            foreach (string s in from1to2)
            {
                if (GameObject.Find(s).GetComponent<MagicObelisk>().activated)
                {
                    g = point2;
                    return g;
                }
            }
            return g;
        }
    }

    public override void ping()
    {
        changed = true;
    }

}
