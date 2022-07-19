using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectOutput : MonoBehaviour
{
    private bool selected;
    private Transform selectedBy;

    private Transform child;
    private Transform previousChild;
    public Transform GetChild { get { return child; } }

    [SerializeField]private RectTransform SetPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Input")
        {
            if (collision.transform.parent.GetComponent<CanvasGroup>().blocksRaycasts == false)
            {
                selected = true;
                selectedBy = collision.transform.parent;
            }
            
        }
    }

    private void Update()
    {
        if (selected && selectedBy.GetComponent<CanvasGroup>().blocksRaycasts == true)
        {/*
            if(selectedBy != child)
            {
                SetChild(selectedBy);
            }
            */
            SetChild(selectedBy);//cambiar luego
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Input")
        {
            selected = false;
            selectedBy = null;
        }
    }

    public void SetChild(Transform newChild)
    {
        print("set child");
        newChild.GetComponent<RectTransform>().position = SetPosition.position;
        newChild.SetParent(transform.parent);
        previousChild = child;
        child = newChild;
        /*
        DragObjectOutput childOutput = child.GetChild(0).GetComponent<DragObjectOutput>();
        if (childOutput.GetChild != null)
        {
            childOutput.SetChild(previousChild);
        }
        */
    }
}
