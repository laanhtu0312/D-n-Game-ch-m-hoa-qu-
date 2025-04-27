using UnityEngine;

public class FruitCut : MonoBehaviour
{
    public TrailRenderer trail;
    public float minCuttingVelocity = 0.001f;

    private Vector2 previousPosition;
    private bool isCutting = false;
    private Camera cam;
    private Collider2D cutCollider;

    void Start()
    {
        cam = Camera.main;
        cutCollider = GetComponent<Collider2D>();
        cutCollider.enabled = false; // Tắt collider ban đầu
        trail.enabled = false;       // Ẩn trail ban đầu
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCut();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCut();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void StartCut()
    {
        isCutting = true;
        trail.enabled = true;
        cutCollider.enabled = true;

        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        trail.transform.position = previousPosition;
    }

    void StopCut()
    {
        isCutting = false;
        trail.enabled = false;
        cutCollider.enabled = false;
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        float velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;

        // Có thể dùng velocity để kiểm tra nếu muốn tối ưu
        trail.transform.position = newPosition;
        transform.position = newPosition;

        previousPosition = newPosition;
    }
}
