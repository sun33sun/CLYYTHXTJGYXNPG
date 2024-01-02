// LineRendererCtrler.cs
using UnityEngine;

/// <summary>
/// LineRenderer控制器
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class LineRendererCtrler : MonoBehaviour
{
	BezierCurve bezier;


	[SerializeField] int accuracy = 20;
	[SerializeField] LineRenderer lineRenderer;
	[SerializeField] Transform[] points;
	[SerializeField] int height = 5;

	void Awake()
	{
		lineRenderer.positionCount = accuracy + 1;
		bezier = new BezierCurve(points, accuracy, height);
	}

	void Update()
	{
		// 更新LineRenderer的点
		bezier.height = height;
		//Vector3 pre = points[0].position;
		//lineRenderer.SetPosition(0, pre);

		for (int i = 0; i <= accuracy; ++i)
		{
			Vector3 to = bezier.QuardaticBezierCurve(i / (float)accuracy);
			lineRenderer.SetPosition(i, to);
		}
	}
}

