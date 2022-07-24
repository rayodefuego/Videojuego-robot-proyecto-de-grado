using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    [SerializeField] private RectTransform SetPosition;

    private Transform objZone;

    private Transform child;
    private Transform previousChild;

    public Transform GetChild { get { return child; } }

    private void Awake()
    {
        objZone = GameObject.Find("Obj Zone").transform;
    }
    public void SetChild(Transform newChild)
    {
        print("set child");
        newChild.GetComponent<RectTransform>().position = SetPosition.position;
        newChild.SetParent(transform);
        
        ChildManager childChildManager = newChild.GetComponent<ChildManager>();

        if(child != null)
        {
            childChildManager.SetChild(child);
        }

        child = newChild;
        
    }

    public void RemoveChild()
    {
        child = null;
    }
    public void SeparateOfHirarchy()
    {

        ChildManager parentChildManager = transform.parent.GetComponent<ChildManager>();
        if(parentChildManager != null)
        {
            parentChildManager.RemoveChild();
        }
        transform.SetParent(objZone);
    }
}
