using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polaroid : MonoBehaviour
{
    public Renderer polaroid;
    public BoxCollider hitbox;

    public void SetImage(Texture2D texture)
    {
        polaroid.material.mainTexture = texture;
    }
}
