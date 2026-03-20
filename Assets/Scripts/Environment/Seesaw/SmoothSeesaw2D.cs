using System.Collections.Generic;
using UnityEngine;

public class SmoothSeesaw2D : MonoBehaviour
{
    public float maxAngle = 25f;
    public float speed = 5f;
    public float maxDistance = 3f; // distance from center for full effect
    public float deadZone = 0.2f;

    private List<GameObject> allObjects = new List<GameObject>();

    void Update()
    {
        float torque = 0f;
        float centerX = transform.position.x;

        foreach (var obj in allObjects)
        {
            if (obj == null) continue;

            float distance = obj.transform.position.x - centerX;

            // ignore tiny center movement
            if (Mathf.Abs(distance) < deadZone)
                continue;

            // normalize distance (-1 to 1)
            float normalized = Mathf.Clamp(distance / maxDistance, -1f, 1f);

            torque += normalized;
        }

        // convert torque into angle
        float targetAngle = -torque * maxAngle;

        Quaternion targetRot = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * speed);
    }

    public void AddObject(GameObject obj)
    {
        if (!allObjects.Contains(obj))
            allObjects.Add(obj);
    }

    public void RemoveObject(GameObject obj)
    {
        allObjects.Remove(obj);
    }
}