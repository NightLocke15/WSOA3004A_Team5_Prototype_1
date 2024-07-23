//had to be attached to the bridge and need to drag it into the soft/hard switch in its inspector to link
using UnityEngine;

public class ActivatableObject : MonoBehaviour
{
    private bool isActive = false;

    void Start()
    {
        gameObject.SetActive(false); // Ensure the object is inactive at the start
    }

    public void Activate()
    {
        if (!isActive)
        {
            isActive = true;
            gameObject.SetActive(true);
            Debug.Log("Bridge Activated!");
        }
    }

    public void Deactivate()
    {
        if (isActive)
        {
            isActive = false;
            gameObject.SetActive(false);
            Debug.Log("Bridge Deactivated!");
        }
    }

    public void Toggle()
    {
        if (isActive)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    public bool IsActive()
    {
        return isActive;
    }
}
