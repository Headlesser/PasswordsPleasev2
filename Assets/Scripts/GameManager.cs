using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //http://www.unitygeek.com/unity_c_singleton/
    public static GameManager ins;
    //[HideInInspector]
    public Node currentNode;

    public List<string> Inventory = new List<string>();
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
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
        {
            currentNode.GetComponent<Prop>().loc.MoveToNode();
        }
        if(Input.GetMouseButtonDown(1) && currentNode.GetComponent<Location>().loc != null && currentNode.GetComponent<Prop>() == null)
        {
            currentNode.GetComponent<Location>().loc.MoveToNode();
        }
    }
}
