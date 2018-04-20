using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGate : MonoBehaviour {

    bool updated = false;
    bool open = false;
    bool moving = false;
    public string[] positives;
    public string[] negatives;
    float topY;
    public float descent = 3F;
    public float speed = 0.2F;


	void Start () {
        topY = transform.position.y;
	}
	

	void Update () {

        if (updated)
        {
            bool targetposition = true;
            foreach(string n in positives)
            {
                if (!GameObject.Find(n).GetComponent<MagicObelisk>().activated) targetposition = false;
            }
            foreach (string n in negatives)
            {
                if (GameObject.Find(n).GetComponent<MagicObelisk>().activated) targetposition = false;
            }
            if(open!=targetposition)
            {
                open = targetposition;
                moving = true;
            }
            updated = false;
        }

        if(moving) {
            if (open)
            {
                transform.position -= Vector3.up * speed;
                if (transform.position.y < topY - descent)
                {
                    setAtBottom();
                    moving = false;
                }
            }
            else
            {
                transform.position += Vector3.up * speed;
                if(transform.position.y > topY)
                {
                    setAtTop();
                    moving = false;
                }
            }
        }
	}

    public void ping()
    {
        updated = true;
    }

    void setAtTop()
    {
        transform.position.Set(transform.position.x, topY, transform.position.z);
    }

    void setAtBottom()
    {
        transform.position.Set(transform.position.x, topY - descent, transform.position.z);
    }
}
