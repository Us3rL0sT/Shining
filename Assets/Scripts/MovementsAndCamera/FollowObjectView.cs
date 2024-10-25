using UnityEngine;

public class FollowObjectView : MonoBehaviour
{
    [SerializeField]
    private Transform fpsTransformView;
    [SerializeField]
    private bool isFpsView = true;

    private void Update()
    {
        transform.position = fpsTransformView.position;
    }
}
