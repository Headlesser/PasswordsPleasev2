using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public Transform camPos;
    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;

    public float camSpeed = 0.5f;

    void Start()
    {
        col = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        MoveToNode();
    }

    public void MoveToNode()
    {
        GameManager.ins.readyToGrab = false;

        //leave the existing node
        if(GameManager.ins.currentNode != null)
        {
            GameManager.ins.currentNode.LeaveNode();
        }

        ///set current node
        GameManager.ins.currentNode = this;

        //move camera
        Sequence seq = DOTween.Sequence();
        seq.Append(Camera.main.transform.DOMove(camPos.position, camSpeed));
        seq.Join(Camera.main.transform.DORotate(camPos.rotation.eulerAngles, camSpeed));

        //Camera.main.transform.position = camPos.position;
        //Camera.main.transform.rotation = camPos.rotation;

        //turn off our own collider
        if(col != null)
        {
            //print("Off" + col);
            col.enabled = false;
        }

        //turn on all reachable node colliders
        foreach (Node node in reachableNodes)
        {
            print("On" + node);
            if(node.col != null)
            {
                node.col.enabled = true;
            }
        }

         GameManager.ins.readyToGrab = true;
        
    }

    public void LeaveNode()
    {
        //turn off all reachable node colliders
        foreach (Node node in reachableNodes)
        {
            //print("Leaving" + node);
            if(node.col != null)
            {
                col.enabled = false;
            }
        }
    }

}
