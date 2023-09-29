using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] float effectSpeed;
    [SerializeField] int damage = 2;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float effectShowTime;
    [SerializeField] float time;
    [SerializeField] float targetScale;
    void Start()
    {
        rb.velocity = transform.right * effectSpeed;
        
        StartCoroutine("effectDestroy");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var monter in GameObject.FindObjectsOfType<Monster>())
        {
            if (collision.gameObject == monter.gameObject)
                collision.gameObject.GetComponent<MonsterHealth>().TakeDamage(damage);

            else
                Debug.Log("");
        }
        
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
