using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : Interactable
{
    private Socket activeSocket = null;

    public override void StartInteraction(Hand hand)
    {
        hand.Pickup(this);
    }

    public override void Interaction(Hand hand)
    {
        print("Interacting");
    }

    public override void EndInteraction(Hand hand)
    {
        hand.Drop();
        print("stopinteracting");
    }

    public void AttachNewSocket(Socket newSocket)
    {
        if (newSocket.GetStoredObject())
            return;

        ReleaseOldSocket();
        activeSocket = newSocket;

        activeSocket.Attach(this);
        isAvailable = false;
    }

    public void ReleaseOldSocket()
    {
        if (!activeSocket)
            return;

        activeSocket.Detach();

        activeSocket = null;
        isAvailable = true;
    }

}
