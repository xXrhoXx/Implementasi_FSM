using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    void LateUpdate()
    {
        if (GetComponentInParent<CharacterMovement>())
        {
            var right = GetComponentInParent<CharacterMovement>().facingRight ? 1 : -1;

            transform.localScale = new Vector3(
                originalScale.x * right,
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }
}
