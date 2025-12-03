using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaceObject()
    {
        if (draggingObject == null)
        {
            Debug.Log("PlaceObject: draggingObject == null");
            return;
        }

        if (currentContainer == null)
        {
            Debug.Log("PlaceObject: currentContainer == null (mouse tidak di atas tile?)");
            return;
        }

        ObjectDragging dragging = draggingObject.GetComponent<ObjectDragging>();
        if (dragging == null || dragging.card == null)
        {
            Debug.Log("PlaceObject: tidak menemukan ObjectDragging / card");
            return;
        }

        // INSTANSIASI PLANT-ASLI SEBAGAI ANAK DARI TILE
        GameObject plant = Instantiate(
            dragging.card.object_Game,
            currentContainer.transform
        );

        plant.transform.localPosition = Vector3.zero; // taruh di tengah tile

        Debug.Log("PlaceObject: plant spawned di " + currentContainer.name);

        ObjectContainer container = currentContainer.GetComponent<ObjectContainer>();
        if (container != null)
        {
            container.isFull = true;
        }
    }
}