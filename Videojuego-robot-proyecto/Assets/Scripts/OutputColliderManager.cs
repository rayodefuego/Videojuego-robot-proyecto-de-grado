using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputColliderManager : MonoBehaviour
{
    DragObjectOutput dragObjectOutput;
    private void Awake()
    {
        dragObjectOutput = transform.parent.GetComponent<DragObjectOutput>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dragObjectOutput.OnCollisionWithInputEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dragObjectOutput.OnCollisionWithInputExit(collision);
    }
}
