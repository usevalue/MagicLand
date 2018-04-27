using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour {


    public int castTime = 100;
    public int cooldown = 200;
    int castClock = 0;
    public float castingRange = 5F;
    MagicObelisk[] obelisks;
    MagicIdol[] idols;

    void Start() {
        obelisks = FindObjectsOfType<MagicObelisk>();
        idols = FindObjectsOfType<MagicIdol>();
        Debug.Log(obelisks.Length + " obelisks and " + idols.Length + " idols found.");
    }

    void Update() {

        if (Input.GetKey("e"))
        {
            startCast();
        }

        if(castClock>0)
        {
            if(castClock==castTime)
            {
                castSpell();
            }
            castClock++;
            if (castClock == castTime + cooldown) castClock = 0;
        }

        if(dead)
        {
            if(Time.fixedTime-timeOfDeath>6)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("copy-scene");
            }
        }
    }

    public void startCast()
    {
        if (castClock == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundLibrary.lib.castSpell, 0.05f);
            castClock++;
        }
    }

    public void castSpell()
    {
        foreach (MagicObelisk o in obelisks)
        {
            if ((o.GetComponent<Transform>().position - GetComponent<Transform>().position).magnitude < castingRange)
            {
                o.toggle();
            }
        }
        foreach (MagicIdol i in idols)
        {
            if ((i.GetComponent<Transform>().position - GameObject.Find("Homunculus").GetComponent<Transform>().position).magnitude < castingRange)
            {
                i.ping();
            }
        }
    }

    bool dead = false;
    float timeOfDeath;
    public void die()
    {
        if (!dead)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundLibrary.lib.death, 0.6F);
            dead = true;
            timeOfDeath = Time.fixedTime;
        }
    }
}
