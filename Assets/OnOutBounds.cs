/*
    Just executes a function (specified in editor) when this's parent goes
    beyond the specified boundaries
*/

using UnityEngine;
using UnityEngine.Events;

public class OnOutBounds : MonoBehaviour
{

    [SerializeField] private float leftBound = -10;
    [SerializeField] private float rightBound = 10;
    [SerializeField] private float upBound = 10;
    [SerializeField] private float downBound = -7;
    public UnityEvent OnExitBoundary;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x < leftBound || pos.x > rightBound || pos.y < downBound || pos.y > upBound)
        {
            OnExitBoundary.Invoke();
        }
    }
}
