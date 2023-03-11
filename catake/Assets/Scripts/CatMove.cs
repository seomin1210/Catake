using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public Transform segmentPrefab;
    public Transform catTailPrefab;

    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();

    public int initialSize = 4;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -90);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }
    }
    private void FixedUpdate()
    {
        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
            //catTailPrefab.position = _segments[i].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
            );
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }
    private void ResetState()
    {
        for(int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
        _direction = Vector2.right;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mouse")
        {
            Grow();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
