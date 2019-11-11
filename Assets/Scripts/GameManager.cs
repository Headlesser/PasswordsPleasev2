using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //http://www.unitygeek.com/unity_c_singleton/
    public static GameManager ins;
    //[HideInInspector]
    public Node currentNode;

    public List<Prop> Inventory = new List<Prop>();
    [HideInInspector]
    public Node start;

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
    }

    void Update()
    {
        //allow the player to 'back up' from a node by pressing right click
        //This is triggering twice for some reason if I'm moving back from a prop.
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            print("My current location is: " + currentNode);
            print("The location of this node is the: " + currentNode.GetComponent<Prop>().loc);
            currentNode.GetComponent<Prop>().loc.MoveToNode();
            print("I have changed my current location to: " + currentNode);
        }
        if(Input.GetMouseButtonDown(1) && currentNode.GetComponent<Location>() != null) //&& currentNode.GetComponent<Prop>() == null)
        {
            print("My current location is: " + currentNode);
            print("The location of this node is the: " + currentNode.GetComponent<Location>().loc);
            currentNode.GetComponent<Location>().loc.MoveToNode();
            print("I have changed my current location to: " + currentNode);
        }
    }
}
