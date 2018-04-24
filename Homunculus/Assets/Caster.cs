using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour {

    bool casting = false;
    int castingMeter = 0;
    public int castingTime = 500;
    public float castingRange = 5F;
    int castCount = 0;
    public int quietTime = 500;
    public AudioClip death;
    MagicObelisk[] obelisks;
    MagicIdol[] idols;

	void Start () {
        obelisks = FindObjectsOfType<MagicObelisk>();
        idols = FindObjectsOfType<MagicIdol>();
        Debug.Log(obelisks.Length + " obelisks and "+idols.Length+" idols found.");
        if (quietTime >= 0)
        {
            GetComponent<AudioListener>().enabled = false;
            GetComponent<AudioSource>().enabled = false;
        }
	}
	
	void Update () {
        if (quietTime > 0) quietTime--;
        else if (quietTime == 0)
        {
            GetComponent<AudioListener>().enabled = true;
            GetComponent<AudioSource>().enabled = true;
            GetComponent<AudioSource>().Play();
            quietTime--;
        }

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

    public void die()
    {
        GetComponent<AudioSource>().PlayOneShot(death,1F);
    }
}
