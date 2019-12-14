using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip[] songs;
    int songNum = 0;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        StartCoroutine(PlayPlaylist());
    }

    IEnumerator PlayPlaylist()
    {
        //play the song
        audioSource.Play();

        //wait until the song is over to proceed
        yield return new WaitForSeconds(audioSource.clip.length);

        //move to the next song in the array
        songNum++;

        //if the song number is higher than array length, reset it
        if(songNum > songs.Length - 1)
        {
            songNum = 0;
        }

        //set the clip to the song in the array index
        audioSource.clip = songs[songNum];

        //restart the process
        StartCoroutine(PlayPlaylist());
    }
}
