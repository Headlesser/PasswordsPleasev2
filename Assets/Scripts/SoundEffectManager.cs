using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public GameManager gm;
    public AudioClip papersClip;

    private AudioSource audioSource;
    bool soundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO Fix this
        /*
        if (GameManager.gameManager.currentNode.name == "DeskPapers" && soundPlayed == false)
        {
            audioSource.PlayOneShot(papersClip);
            soundPlayed = true;
        }
        else if (GameManager.gameManager.currentNode.name != "DeskPapers" && soundPlayed == true) 
        {
            soundPlayed = false;
        }
        */
    }
}
