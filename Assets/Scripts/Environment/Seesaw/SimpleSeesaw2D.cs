using System.Collections.Generic;
using UnityEngine;

public class SimpleSeesaw2D : MonoBehaviour
{
    public float maxAngle = 20f;
    public float speed = 5f;
    public float returnDelay = 2f; // seconds before going back to center

    private List<GameObject> leftObjects = new List<GameObject>();
    private List<GameObject> rightObjects = new List<GameObject>();

    private float balanceTimer = 0f;
    private bool isBalanced = false;

    void Update()
    {
        float leftWeight = leftObjects.Count;
        float rightWeight = rightObjects.Count;

        float targetAngle = transform.eulerAngles.z;

        if (leftWeight > rightWeight)
        {
            targetAngle = maxAngle;
            isBalanced = false;
            balanceTimer = 0f;
        }
        else if (rightWeight > leftWeight)
        {
            targetAngle = -maxAngle;
            isBalanced = false;
            balanceTimer = 0f;
        }
        else
        {
            // Balanced → start timer
            if (!isBalanced)
            {
                isBalanced = true;
                balanceTimer = 0f;
            }

            balanceTimer += Time.deltaTime;

            if (balanceTimer >= returnDelay)
            {
                targetAngle = 0f; // return to center AFTER delay
            }
        }

        Quaternion targetRot = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * speed);
    }

    public void AddLeft(GameObject obj)
    {
        if (!leftObjects.Contains(obj))
            leftObjects.Add(obj);
    }

    public void RemoveLeft(GameObject obj)
    {
        leftObjects.Remove(obj);
    }

    public void AddRight(GameObject obj)
    {
        if (!rightObjects.Contains(obj))
            rightObjects.Add(obj);
    }

    public void RemoveRight(GameObject obj)
    {
        rightObjects.Remove(obj);
    }
}