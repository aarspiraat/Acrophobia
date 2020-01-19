using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool isAvailable = true;

    public virtual void StartInteraction(Hand hand)
    {
        print("Start");
    }
    public virtual void Interaction(Hand hand)
    {
        print("Interacting");
    }
    public virtual void EndInteraction(Hand hand)
    {
        print("End");
    }
    public bool getAvailability()
    {
        return isAvailable;
    }
}
