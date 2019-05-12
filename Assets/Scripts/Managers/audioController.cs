using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    private AudioSource audios;
    private AudioSource piece;
    public AudioClip[] source;
    private AudioClip clip;
    public static List<AudioClip> music = new List<AudioClip>();

    public static audioController instance;


    void Start()
    {
        instance = GetComponent<audioController>();
        audios = gameObject.GetComponent<AudioSource>();
        clip = gameObject.GetComponentInChildren<AudioClip>();

    }

    public void playNote()
    {
        int rand = Random.Range(0, 14);
        clip = source[rand];
        audios.clip = clip;
        audios.Play();

        // source = Instantiate(audios[rand]);
        music.Add(source[rand]);

    }
    IEnumerator play()
    {
        for (int i = 0; i < music.Count; i++)
        {
            piece.PlayOneShot(music[i]);
            yield return new WaitForSeconds(1);
        }
    }
    public void playSong()
    {
        for (int i = 0; i < music.Count; i++)
        {
            piece = gameObject.GetComponent<AudioSource>();
            piece.clip = music[i];
        }
        StartCoroutine(play());
            
    }




}
