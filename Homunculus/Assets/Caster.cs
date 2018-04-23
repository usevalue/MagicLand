using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour {

    bool casting = false;
    int castingMeter = 0;
    public int castingTime = 1000;
    public float castingRange = 5F;
    int castCount = 0;
    MagicObelisk[] obelisks;
    MagicIdol[] idols;

	void Start () {
        obelisks = FindObjectsOfType<MagicObelisk>();
        idols = FindObjectsOfType<MagicIdol>();
        Debug.Log(obelisks.Length + " obelisks and "+idols.Length+" idols found.");
	}
	
	void Update () {
        if (Input.GetKey("e"))
        {
            if (!casting)
            {
                casting = true;
                castingMeter = 0;
            }
            else castingMeter++;

            if (castingMeter >= castingTime)
            {
                castSpell();
                casting = false;
                castingMeter = 0;
                castCount++;
            }
        }
        else if (casting)
        {
            casting = false;
            castingMeter = 0;
        }
	}

    void castSpell()
    {
        foreach (MagicObelisk o in obelisks)
        {
            if((o.GetComponent<Transform>().position-GetComponent<Transform>().position).magnitude<castingRange)
            {
                o.toggle();
            }
        }
        foreach(MagicIdol i in idols)
        {
            if ((i.GetComponent<Transform>().position - GetComponent<Transform>().position).magnitude < castingRange)
            {
                i.ping();
            }
        }
    }
}
