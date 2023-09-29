using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] float effectSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float effectShowTime;
    [SerializeField] float time;
    [SerializeField] float targetScale;
    void Start()
    {
        rb.velocity = transform.right * effectSpeed;
        
        StartCoroutine("effectDestroy");

    }
    private void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, Mathf.Lerp(gameObject.transform.localScale.y, targetScale, time / 3f), gameObject.transform.localScale.z);
    }
    IEnumerator effectDestroy()
    {
        yield return new WaitForSeconds(effectShowTime);
        Destroy(gameObject);
    }
}
