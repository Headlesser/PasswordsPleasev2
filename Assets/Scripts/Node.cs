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

    public BoxCollider interactCollider;

    void Start()
    {
        col = GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        //print("beep");
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
                //print("On" + node);
                if (node.col != null)
                {
                    node.col.enabled = true;
                }
            }

            ///set current node
            GameManager.gameManager.currentNode = this;

            StartCoroutine(ArriveAtNode());
        }
    }

    public IEnumerator ArriveAtNode() //this was really hacky lmao
    {
        yield return new WaitForSeconds(0.1f);

        foreach(GameObject obj in collectableObjects)
        {
            obj.GetComponent<PickUpable>().readyToGrab = true;
        }

        if (interactCollider != null)
            interactCollider.enabled = true;
            GameManager.gameManager.Monologue(GameManager.gameManager.currentNode);
    }

    public void LeaveNode()
    {
        if (interactCollider != null)
            interactCollider.enabled = false;

        foreach (GameObject obj in collectableObjects)
        {
            obj.GetComponent<PickUpable>().readyToGrab = false;
        }

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
