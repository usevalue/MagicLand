using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Caster : MonoBehaviour {

    GameObject spell;
    public int castTime = 100;
    public int cooldown = 200;
    int castClock = 0;
    public float castingRange = 5F;
    MagicObelisk[] obelisks;
    MagicIdol[] idols;


    // Wand peripheral
    public string portName = "COM3";
    SerialPort stream;
    bool usingWand = false;
    public bool wandPresent()
    {
        return usingWand;
    }


    void Start() {
        stream = new SerialPort(portName, 9600);
        // What is input?
        try
        {
            stream.Open();
            stream.ReadTimeout = 1;
            usingWand = true;
        }
        catch (System.IO.IOException e)
        {
            Debug.Log("No wand available.");
        }

        obelisks = FindObjectsOfType<MagicObelisk>();
        //idols = FindObjectsOfType<MagicIdol>();
        spell = GameObject.Find("Spell");
    }

    void Update() {

        if (!usingWand&&Input.GetKey("e"))
        {
            waveWand();
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

    public void waveWand()
    {
        if (castClock == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundLibrary.lib.castSpell, 1f);
            spell.GetComponent<ParticleSystem>().Play();
            castClock++;
        }
    }


    public void castSpell()
    {
        //MagicObelisk target;

        foreach (MagicObelisk o in obelisks)
        {
            if ((o.GetComponent<Transform>().position - GetComponent<Transform>().position).magnitude < castingRange)
            {
                o.toggle();
            }
        }

        /*
        foreach (MagicIdol i in idols)
        {
            if ((i.GetComponent<Transform>().position - GameObject.Find("Homunculus").GetComponent<Transform>().position).magnitude < castingRange)
            {
                i.ping();
            }
        }
        */
    }

    bool dead = false;
    float timeOfDeath;
    public void die()
    {
        if (!dead)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundLibrary.lib.death, 0.45F);
            dead = true;
            timeOfDeath = Time.fixedTime;
        }
    }
}
