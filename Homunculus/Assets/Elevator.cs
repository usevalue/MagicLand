using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MagicSensitive {

    public float topX;
    public float topY;
    public float topZ;
    public float bottomX;
    public float bottomY;
    public float bottomZ;
    public float speed = 1;
    public string[] positives;
    bool ascending;
    bool moving = false;
    Vector3 top;
    Vector3 bottom;

    Vector3 rise;

	void Start () {
        top = new Vector3(topX, topY, topZ);
        bottom = new Vector3(bottomX, bottomY, bottomZ);
        rise = top-bottom;
        ascending = true;
        foreach(string s in positives)
        {
           // if (!GameObject.Find(s).GetComponent<MagicObelisk>().activated)
                //ascending = false;
        }

        //if (ascending)
        //{
        GetComponent<Transform>().position += rise;
        //}
        //else GetComponent<Transform>().position.Set(bottomX, bottomY, bottomZ);
	}
	
	void Update () {
		
	}

    public override void ping()
    {

    }

}
