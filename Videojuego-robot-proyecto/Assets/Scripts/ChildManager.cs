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
        
        ChildManager childChildManager = newChild.GetChild(0).GetComponent<ChildManager>();

        if(child != null)
        {
            childChildManager.SetChild(child);
        }

        child = newChild;
        
    }
}
