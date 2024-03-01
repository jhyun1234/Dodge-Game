using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMaterial : MonoBehaviour
{
    [SerializeField] Material flashmaterial;

    private Material originMaterial;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        originMaterial = spriteRenderer.material;
    }

    public IEnumerator HitEffect(float duration)
    {
        spriteRenderer.material = flashmaterial;

        yield return new WaitForSeconds(duration);

        spriteRenderer.material = originMaterial;
    }

    
}
