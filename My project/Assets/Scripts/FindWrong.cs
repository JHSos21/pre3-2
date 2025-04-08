using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindWrong : MonoBehaviour
{
    public GameObject Canvas;
    public float circleRadius = 0.3f;
    public int segments = 100;
    public float drawDuration = 0.5f;
    private HashSet<Transform> markedSpots = new HashSet<Transform>();
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPos2D = new Vector2(worldPos.x, worldPos.y);
            RaycastHit2D hit = Physics2D.Raycast(clickPos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Transform target = hit.collider.transform;
                if (!markedSpots.Contains(target))
                {
                    markedSpots.Add(target);
                    StartCoroutine(DrawCircleAt(target.position));
                }
            }
            else
            {
                Canvas.GetComponent<Heart>().Miss();
            }
        }
    }
    IEnumerator DrawCircleAt(Vector3 position)
    {
        GameObject circle = new GameObject("Circle");
        circle.transform.position = position;
        LineRenderer line = circle.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = line.endWidth = 0.05f;
        line.positionCount = 0;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = line.endColor = Color.red;
        float angleStep = 360f / segments;
        for (int i = 0; i <= segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * circleRadius;
            float y = Mathf.Sin(angle) * circleRadius;
            line.positionCount = i + 1;
            line.SetPosition(i, new Vector3(x, y, 0));
            yield return new WaitForSeconds(drawDuration / segments);
        }
        Canvas.GetComponent<HowMany>().SumAns();
    }
}