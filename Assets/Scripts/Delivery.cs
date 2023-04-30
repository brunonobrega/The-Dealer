using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.3f;
    [SerializeField] Color32 hasPackageColor = new Color32(255, 0, 0, 255);
    [SerializeField] Color32 deliveredPackageColor = new Color32(255, 170, 0, 0);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    bool hasPackage;
    float colorDelay = 1f;
    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage) 
        {
            Debug.Log("Package pickd up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;

            Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.tag == "Customer" && hasPackage) 
        {
            Debug.Log("Delivered package");
            hasPackage = false;

            spriteRenderer.color = deliveredPackageColor;

            StartCoroutine(ChangeColorDelay(colorDelay, noPackageColor));
            
        }

        if (other.tag == "StartLine") 
        {
            Debug.Log("Timer running");
        }
    }

    IEnumerator ChangeColorDelay(float time, Color32 color) 
    {
        Debug.Log(time);
        yield return new WaitForSeconds(time);

        spriteRenderer.color = color;
    }
}
