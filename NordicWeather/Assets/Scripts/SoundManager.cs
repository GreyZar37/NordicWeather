using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource musicSource;
    public AudioSource ambientSource;

    public AudioClip[] damagedSfx;
    public AudioClip[] damagedSfxMonsters;
    public AudioClip[] damagedSfxBests;

    public AudioClip[] whooshSfx;
    public AudioClip[] songs;
    
    public AudioClip[] ambientClips;



    // Start is called before the first frame update
    void Start()
    {
        int randomSong = Random.Range(0, songs.Length);
        musicSource.clip = songs[randomSong];
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
