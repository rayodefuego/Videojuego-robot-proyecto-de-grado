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

    public void OnCollisionWithInputEnter(Collider2D collision)
    {
        if (collision.gameObject.tag == "Input")
        {
            print(GetComponent<CanvasGroup>().blocksRaycasts);
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
            print("selected by:" + selectedBy.name);
            childManager.SetChild(selectedBy);
            Unselect();
        }
    }

    public void OnCollisionWithInputExit(Collider2D collision)
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
