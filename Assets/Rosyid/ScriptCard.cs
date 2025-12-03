using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_Drag;   // prefab untuk object yang mengikuti mouse
    public GameObject object_Game;   // prefab plant di map
    public Canvas canvas;

    private GameObject objectDragInstance;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // BUAT COPY, BUKAN MEMINDAHKAN KARTU INI
        objectDragInstance = Instantiate(object_Drag, canvas.transform);
        objectDragInstance.transform.position = Input.mousePosition;

        var dragging = objectDragInstance.GetComponent<ObjectDragging>();
        if (dragging != null)
        {
            dragging.card = this;
        }

        GameManager.Instance.draggingObject = objectDragInstance;

        Debug.Log("OnPointerDown: spawn drag object");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (objectDragInstance != null)
        {
            objectDragInstance.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp: try place object");

        gameManager.PlaceObject();
        gameManager.draggingObject = null;

        // HANYA HAPUS PREVIEW / DRAG
        if (objectDragInstance != null)
        {
            Destroy(objectDragInstance);
            objectDragInstance = null;
        }
    }
}