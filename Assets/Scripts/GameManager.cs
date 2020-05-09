using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public Node currentNode;

    [HideInInspector]
    public Node start;
    public GameObject camLoc;
    public bool readyToGrab;

    public float minInteractDist;

    //GAME STATE BOOLS
    public bool visitedPC;
    public bool openedPC;
    public bool visitedFlowerCabinet;
    public bool openedFlowerCabinet;
    public bool visitedTablet;
    public bool openedTablet;
    public bool visitedDiploma;

    private void Awake()
    {
        if (gameManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameManager = this;
        }
    }

    void Start()
    {
        Camera.main.transform.position = camLoc.transform.position;
        Camera.main.transform.rotation = camLoc.transform.rotation;
    }

    void Update()
    {
        bool triggeredOnce = false; //Keeps the camera from zooming back twice in a row.
        //allow the player to 'back up' from a node by pressing right click
        //This is triggering twice for some reason if I'm moving back from a prop.
        if (Input.GetMouseButtonDown(1) && !triggeredOnce)
        {
            print("I have changed my current location to: " + currentNode);
            currentNode.location.MoveToNode();
            triggeredOnce = true;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetAxis("Interact") > 0.3f)
        {
            CheckHitObj();
        }
    }

    void CheckHitObj()
    {
        if (true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.transform.gameObject.GetComponent<GenericObject>() != null) && (Vector3.Distance(hit.transform.position, this.transform.position) <= minInteractDist))
                {
                    hit.transform.gameObject.GetComponent<GenericObject>().Interact();
                }
            }
        }
    }

    //Check for dialogue
    public void Monologue(Node visiting)
    {
        if(!visiting.visited && visiting.monologue.Length > 0) //Check to see if current node has been visited and if it has a monologue to play
        {
            string[] speech = visiting.monologue;
            visitedPC = true;
            //string[] speech = {"It looks like the computer needs a password to log on. While I could try the brute force method, that could take quite a while if it's not something obvious.", "Huh? The owner left a clue on this sticky note.", "I wonder if they may have written anything else useful down somewhere... I should probably look around before I try guessing." };
            DialogueManager.diagMng.UpdateSpeech(speech);
            DialogueManager.diagMng.Say(speech[0]);
        }
        /*
        if(openedPC && visiting.tag == "PC")
        {
            string[] speech = {"That was too easy! While the clue was reasonable, it's never a good idea to write your password down, especially in a place that's right out in the open. Writing it down on paper defeats the entire purpose of having a clue anyway.", "The second screen has turned on and there's... three security questions?! That's three times the work I have to do!", "Well, considering this person's habits, maybe they left some more clues to the answers laying about their office..." };
            DialogueManager.diagMng.UpdateSpeech(speech);
            DialogueManager.diagMng.Say(speech[0]);
            openedPC = false;
        }
        if(!visitedTablet && visiting.tag == "Tablet")
        {
            visitedTablet = true;
            string[] speech = {"This tablet is locked by a 4 digit pin. While it is better than nothing, pins are pretty easy to guess...", "It's usually a birthday or a year of some sort of significance. Maybe there's something like that in this office?" };
            DialogueManager.diagMng.UpdateSpeech(speech);
            DialogueManager.diagMng.Say(speech[0]);
        }
        if(openedTablet && visiting.tag == "Tablet")
        {
            string[] speech = {"Looks like that was the correct pin! But what's this?", "The gallery app seems to already be open. It looks like a picture of... this room? There's a key hidden inside of a potted plant somewhere.", "While the tablet did have a pin, taking a photo to remember where your stuff is hidden to really isn't the best idea..." };
            DialogueManager.diagMng.UpdateSpeech(speech);
            DialogueManager.diagMng.Say(speech[0]);
        }
        if(!visitedFlowerCabinet && visiting.tag == "FlowerCabinet")
        {
            visitedFlowerCabinet = true;
            string[] speech = {"Huh? This cabinet is locked. I need a key to open it.", "I wonder what's inside that could be so important that this person saw fit to hide it..."};
            DialogueManager.diagMng.UpdateSpeech(speech);
            DialogueManager.diagMng.Say(speech[0]);
        }
        if(openedFlowerCabinet && visiting.tag == "FlowerCabinet")
        {
            string[] speech = {"Alright! That key did the trick, and look! There's a ton of information about flowers in here.", "Pressed MARIGOLD collection, huh? Three guesses what this person's favorite flower is..."};
            DialogueManager.diagMng.UpdateSpeech(speech);
            DialogueManager.diagMng.Say(speech[0]);
        }
        if(!visitedDiploma && visiting.tag == "Diploma")
        {
            visitedDiploma = true;
            string[] speech = {"This looks like a college diploma from Indiana University for... Underwater Basket Weaving?", "Well, I can't say I wish I didn't know how to do that. I wonder if this person has an online store?"};
            DialogueManager.diagMng.UpdateSpeech(speech);
            DialogueManager.diagMng.Say(speech[0]);
        }
        */
    }
}
