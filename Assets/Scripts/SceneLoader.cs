using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    AudioSource clickSound;

    // Start is called before the first frame update
    void Awake()
    {
        clickSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            clickSound.Play();
            SceneManager.LoadSceneAsync(1);
        }
    }
}
