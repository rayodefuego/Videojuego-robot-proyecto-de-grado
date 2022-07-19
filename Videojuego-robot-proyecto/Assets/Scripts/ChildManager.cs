using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    [SerializeField] private RectTransform SetPosition;

    private Transform child;
    private Transform previousChild;

    public Transform GetChild { get { return child; } }
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
