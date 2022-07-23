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
        newChild.SetParent(transform.parent);
        
        ChildManager childChildManager = newChild.GetChild(0).GetComponent<ChildManager>();

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
        transform.parent.GetChild(4).GetChild(0).gameObject.GetComponent<ChildManager>().RemoveChild();
        transform.SetParent(objZone);
    }
}
