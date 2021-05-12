using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroid : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    private float timer;
    private float xSize;
    private float ySize;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block Destroier"))
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Obliviate(float sekonds, float timesBigger)
    {
        xSize = gameObject.transform.localScale.x;
        ySize = gameObject.transform.localScale.y;
        boxCollider.enabled = false;
        while (timer <= 1 && gameObject != null)
        {
            Debug.Log(1);
            timer += Time.deltaTime / sekonds;
            transform.localScale = new Vector3(Mathf.Lerp(xSize, xSize + timesBigger, timer), Mathf.Lerp(ySize, ySize + timesBigger, timer));
            spriteRenderer.color = new Color(1, 1, 1, 1 - timer);
            yield return null;
        }

        
    }
}
