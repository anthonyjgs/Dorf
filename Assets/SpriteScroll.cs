using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroll : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    [SerializeField] private float scrollSpeed = 10f;

    private void Start()
    {
        if (rend == null) rend = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        rend.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime * 1 / transform.localScale.x, 0);
    }
}
