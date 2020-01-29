using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //http://www.unitygeek.com/unity_c_singleton/
    public static GameManager ins;
    public Node currentNode;

    public List<GameObject> Inventory = new List<GameObject>();
    [HideInInspector]
    public Node start;
    public GameObject camLoc;
    public GameObject[] AllPickups; //A list of every object in the scene that can be picked up
    public bool readyToGrab;

    public float minInteractDist;

    private void Awake()
    {
        if (ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ins = this;
            //DontDestroy(gameObject);
        }
    }

    void Start()
    {
        Camera.main.transform.position = camLoc.transform.position;
        Camera.main.transform.rotation = camLoc.transform.rotation;
        AllPickups = GameObject.FindGameObjectsWithTag("Pickup");
    }

    void Update()
    {
        bool triggeredOnce = false; //Keeps the camera from zooming back twice in a row.
        //print(triggeredOnce);
        //allow the player to 'back up' from a node by pressing right click
        //This is triggering twice for some reason if I'm moving back from a prop.
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null && triggeredOnce == false)
        {
            //print("My current location is: " + currentNode);
            //print("The location of this node is the: " + currentNode.GetComponent<Prop>().loc);
            currentNode.GetComponent<Prop>().loc.MoveToNode();
            //print("I have changed my current location to: " + currentNode);
            triggeredOnce = true;
        }
        if(Input.GetMouseButtonDown(1) && currentNode.GetComponent<Location>() != null && triggeredOnce == false) //&& currentNode.GetComponent<Prop>() == null)
        {
            //print("My current location is: " + currentNode);
            //print("The location of this node is the: " + currentNode.GetComponent<Location>().loc);
            currentNode.GetComponent<Location>().loc.MoveToNode();
            //print("I have changed my current location to: " + currentNode);
            
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
                    //Debug.Log(hit.transform.name);
                    hit.transform.gameObject.GetComponent<GenericObject>().Interact();
                }
            }
        }
    }
}
