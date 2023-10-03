using UnityEngine;

public class Mouse : MonoBehaviour
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
            RandomizePosition();
        }
    }
}
