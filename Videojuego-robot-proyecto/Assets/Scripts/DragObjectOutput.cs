using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectOutput : MonoBehaviour
{
    [SerializeField]private RectTransform SetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Input")
        {
            Transform collisionObject = collision.transform.parent;
            if(collisionObject.GetComponent<CanvasGroup>().blocksRaycasts == true)
            {
                collisionObject.GetComponent<RectTransform>().position = SetPosition.position;
                collisionObject.SetParent(transform.parent);
            }
        }
    }
}
