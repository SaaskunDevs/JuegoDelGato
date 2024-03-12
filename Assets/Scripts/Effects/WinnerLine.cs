using UnityEngine;

public class WinnerLine : MonoBehaviour
{
    [SerializeField] private LineRenderer line;

    private float actualTime;
    private float animTime = 2;

    private Vector3 firstPos;
    private Vector3 targetPos;
    private Vector3 actualPos;

    private bool animate;
    private void Update()
    {
        if (animate)
            AnimLine();
    }

    public void GetLinePos(Vector2 start, Vector2 end)
    {

        firstPos = new Vector3(start.x, start.y, -0.8f);
        targetPos = new Vector3(end.x, end.y, -0.8f);

        line.SetPosition(0, firstPos);
        animate = true;
    }


    void AnimLine()
    {
        actualTime += Time.deltaTime;
        actualPos = Vector3.Lerp(firstPos, targetPos, actualTime / animTime);
        line.SetPosition(1, actualPos);

        if (actualTime > animTime)
            animate = false;
    }

}
