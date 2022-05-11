using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    Material mt;
    public float paralax = 2f;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;

        offset = mt.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += Time.deltaTime / paralax;

        mt.mainTextureOffset = offset;
    }
}
