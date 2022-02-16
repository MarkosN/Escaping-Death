using UnityEngine;

public class TrapsCircles : MonoBehaviour // Script responsible for the Circle Traps behavior
{
    public Transform[] destinationPoints; // The points that the trap will "patrol"
    private int currentPoint;             // In which point the trap is
    public float trapSpeed;               // Trap's Speed

    // Use this for initialization
    void Start()
    {
        NextPoint(); // The first point that the trap goes
    }

    // Update is called once per frame
    void Update()
    {
        // Updating traps current position
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);

        // Distance between current position and next position
        if (Vector2.Distance(currentPos, destinationPoints[currentPoint].position) < trapSpeed)
        {
            NextPoint();
        }

        // Using lerp in order to move the traps from one point to another with linear
        transform.position = Vector3.Lerp(transform.position, destinationPoints[currentPoint].position, Time.deltaTime);
    }

    void NextPoint() // Make the trap to move to another point
    {
        if (destinationPoints.Length == 0)
        {
            return;
        }

        transform.position = destinationPoints[currentPoint].position;
        currentPoint = (currentPoint + 1) % destinationPoints.Length;
    }
}