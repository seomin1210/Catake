using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D gridAria;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridAria.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Wait());
            RandomizePosition();
        }
    }
    private IEnumerator Wait()
    {
        float randomDelay = Random.Range(5f, 10f);
        yield return new WaitForSeconds(randomDelay);
    }
}
