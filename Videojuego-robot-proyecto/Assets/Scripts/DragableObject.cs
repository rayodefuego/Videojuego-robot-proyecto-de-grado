using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    [SerializeField] Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private ChildManager childManager;

    private bool isDragging = false;

    public bool IsDragging { get { return isDragging; } }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        childManager = transform.GetChild(0).GetComponent<ChildManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("Start Draging");
        canvasGroup.blocksRaycasts = false;
        isDragging = true;
        childManager.SeparateOfHirarchy();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("End Draging");
        canvasGroup.blocksRaycasts = true;
        isDragging = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Pointer Down");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
