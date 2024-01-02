using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 贝塞尔曲线
/// </summary>
public class BezierCurve
{
	/// <summary>
	/// 控制点（包括起始点和终止点）
	/// </summary>
	Transform[] points = new Transform[2];

	/// <summary>
	/// 精确度
	/// </summary>
	public int accuracy = 20;

	/// <summary>
	/// 贝塞尔曲线的高度
	/// </summary>
	public int height = 3;

	public BezierCurve(Transform[] points, int accuracy, float height)
	{
		this.accuracy = accuracy;
		for (int i = 0; i < this.points.Length; i++)
		{
			this.points[i] = points[i].transform;
		}
	}

	/// <summary>
	/// 二阶贝塞尔
	/// </summary>
	/// <param name="t">时间参数，范围0~1</param>
	/// <returns></returns>
	public Vector3 QuardaticBezierCurve(float t)
	{
		Vector3 a = points[0].position;
		Vector3 b = (points[0].position + points[1].position) / 2;
		b.y += height;
		Vector3 c = points[1].position;

		Vector3 aa = a + (b - a) * t;
		Vector3 bb = b + (c - b) * t;
		return aa + (bb - aa) * t;
	}

	public List<Vector3> Formula(List<Vector3> list, float t)
	{


		return new List<Vector3>();
	}
}
