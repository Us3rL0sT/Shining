using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public float scaleSpeed = 1f;
    public Vector3 targetScale = new Vector3(1f, 1f, 1f);

    private float currentY = 0.1f;
    private bool scalingY = false;

    private void Start()
    {

        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        currentY = 0.1f;
    }

    private void Update()
    {
        Vector3 newScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale.x, currentY, targetScale.z), scaleSpeed * Time.deltaTime);
        transform.localScale = newScale;

        if (Vector3.Distance(new Vector3(transform.localScale.x, 0, transform.localScale.z), new Vector3(targetScale.x, 0, targetScale.z)) < 0.01f)
        {
            scalingY = true;
        }

        if (scalingY)
        {
            currentY = Mathf.Lerp(currentY, targetScale.y, scaleSpeed * Time.deltaTime);

            transform.localScale = new Vector3(transform.localScale.x, currentY, transform.localScale.z);

            float heightDifference = (currentY - transform.localScale.y) / 2;
            transform.position += new Vector3(0, heightDifference, 0);
        }

        if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
        {
            enabled = false;
        }
    }
}
