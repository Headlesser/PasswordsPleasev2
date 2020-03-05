using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Node : MonoBehaviour
{
    public Transform camPos;
    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;

    public float camSpeed = 0.5f;

    public List<GameObject> collectableObjects;

    public Node location;

    void Start()
    {
        col = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        print("beep");
        MoveToNode();
    }

    public void MoveToNode()
    {
        if (!DialogueManager.diagMng.talking)
        {
            //leave the existing node
            if (GameManager.gameManager.currentNode != null)
            {
                GameManager.gameManager.currentNode.LeaveNode();
            }

            ///set current node
            GameManager.gameManager.currentNode = this;

            //move camera
            Sequence seq = DOTween.Sequence();
            seq.Append(Camera.main.transform.DOMove(camPos.position, camSpeed));
            seq.Join(Camera.main.transform.DORotate(camPos.rotation.eulerAngles, camSpeed));

            //turn off our own collider
            if (col != null)
            {
                //print("Off" + col);
                col.enabled = false;
            }

            //turn on all reachable node colliders
            foreach (Node node in reachableNodes)
            {
                print("On" + node);
                if (node.col != null)
                {
                    node.col.enabled = true;
                }
            }
        }
    }

    public void LeaveNode()
    {
        //turn off all reachable node colliders
        foreach (Node node in reachableNodes)
        {
            if(node.col != null)
            {
                col.enabled = false;
            }
        }
    }

}
