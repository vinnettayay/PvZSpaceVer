using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour
{
    public bool isFull;
    public Image backgroundImage;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.draggingObject != null && !isFull)
        {
            gameManager.currentContainer = this.gameObject;

            if (backgroundImage != null)
                backgroundImage.enabled = true;

            Debug.Log("Container " + name + ": ENTER");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameManager.currentContainer == this.gameObject)
        {
            gameManager.currentContainer = null;
        }

        if (backgroundImage != null)
            backgroundImage.enabled = false;

        Debug.Log("Container " + name + ": EXIT");
    }
}