using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectOutput : MonoBehaviour
{
    private bool selected;
    private Transform selectedBy;

    private ChildManager childManager;

    private void Awake()
    {
        childManager = GetComponent<ChildManager>();
    }

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
        {
            childManager.SetChild(selectedBy);
            Unselect();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Input")
        {
            Unselect();
        }
    }

    public void Unselect()
    {
        selected = false;
        selectedBy = null;
    }

}
