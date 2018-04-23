using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdolPuzzle : MonoBehaviour {

    string[] sequence = {"idol4","idol2","idol1","idol3"};
    int index = 0;
    public List<MagicIdol> idols;

    AudioSource asound;
    bool playing = false;
    bool victory = false;
    AudioSource[] soundEffects;

    private void Start()
    {
        soundEffects = GetComponents<AudioSource>();
        idols = new List<MagicIdol>();
        GameObject[] stones = GameObject.FindGameObjectsWithTag("Idols");
		Debug.Log (stones.Length + " idols detected.");
        for(int x = 0; x<stones.Length; x++)
        {
            idols.Add(stones[x].GetComponent<MagicIdol>());
        }
    }

    // Update is called once per frame
    void Update () {
        for(int x=0; x < idols.Count; x++)
        {
            if(idols[x].isActivated())
            {
                if(sequence[index].Equals(idols[x].name)) // Correct item in sequence
                {
                    idols[x].lightUp();
                    index++;
                    if (index<idols.Count) // More to go
                    {
                        soundEffects[1].Play();
                    }
                    else
                    {
                        soundEffects[1].Play();
                        GameObject.Find("G1").GetComponent<MagicGate>().ping();
                        index = 0;
                    }
                }
                else // Incorrect item in sequence
                {
                    soundEffects[2].Play();
                    index = 0;
                    for(int l=0; l<idols.Count;l++)
                    {
                        idols[l].lightOut();
                    }
                }
                idols[x].deActivate();
            }
        }
    }

}
