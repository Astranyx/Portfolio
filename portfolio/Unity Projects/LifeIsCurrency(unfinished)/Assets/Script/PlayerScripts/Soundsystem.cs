using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundsystem : MonoBehaviour {
    //boomguy audio
    public static bool boom;
    public AudioClip bigboom;
    //punchyboys
    public static bool attack;
    public AudioClip punchyboys;
    //Ivisvisble rangers
    public static bool Invis;
    public AudioClip Invisiboys;
    //Fireball yum!
    public static bool Fireball;
    public AudioClip FireballYum;
    //petrified stoner
    public static bool Petrified;
    public AudioClip petrifiedStoner;

    public static bool nukecola;
    public AudioClip nukeuk;

    AudioSource play;

     void Start()
    {
        play = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
		if (boom)
        {
            play.PlayOneShot(bigboom, 0.6f);
            boom = false;
        }
        if (attack)
        {
            play.PlayOneShot(punchyboys, 0.6f);
            attack = false;
        }
        if (Invis)
        {
            play.PlayOneShot(Invisiboys, 0.6f);
            Invis = false;
        }
        if (Fireball)
        {
            play.PlayOneShot(FireballYum, 0.3f);
            Fireball = false;
        }
        if (Petrified)
        {
            play.PlayOneShot(petrifiedStoner, 0.6f);
            Petrified = false;
        }
        if (nukecola)
        {
            play.PlayOneShot(nukeuk, 0.6f);
            nukecola = false;
        }
        
       
	}
}
