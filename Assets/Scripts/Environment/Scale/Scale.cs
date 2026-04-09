using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField]
    private Transform leftPlatform;
    [SerializeField]
    private Transform rightPlatform;

    [SerializeField]
    private float maxDrop = 2f;
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float offsetPerWeightUnit = 0.8f;


    [SerializeField]
    private int leftWeight = 0;
    [SerializeField]
    private int rightWeight = 0;

    private Vector3 leftOrigin;
    private Vector3 rightOrigin;

    void Start()
    {
        leftOrigin = leftPlatform.position;
        rightOrigin = rightPlatform.position;
    }

    void Update()
    {
        int diff = rightWeight - leftWeight;
        float offset = Mathf.Clamp(diff * offsetPerWeightUnit, -maxDrop, maxDrop);

        Vector3 leftTarget = leftOrigin + Vector3.up * offset;
        Vector3 rightTarget = rightOrigin - Vector3.up * offset;

        leftPlatform.position = Vector3.Lerp(leftPlatform.position, leftTarget, Time.deltaTime * moveSpeed);
        rightPlatform.position = Vector3.Lerp(rightPlatform.position, rightTarget, Time.deltaTime * moveSpeed);
    }

    public void SetWeight(string side, int count)
    {
        if (side == "left") leftWeight = count;
        else rightWeight = count;
    }
}
