using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class LineRadiusOperator
{
	List<KeyValuePair<float, List<LineRenderer>>> lineDic = new List<KeyValuePair<float, List<LineRenderer>>>();
	List<LineRenderer> lines = new List<LineRenderer>();

	public float radius = 1.0f;

	public void Insert(LineRenderer lineRenderer, int index)
	{
		if (!lines.Contains(lineRenderer))
		{
			lines.Insert(index, lineRenderer);
		}
	}

	public void Add(LineRenderer lineRenderer)
	{
		if (!lines.Contains(lineRenderer))
			lines.Add(lineRenderer);
	}

	public void Remove(LineRenderer lineRenderer)
	{
		if (lines.Contains(lineRenderer))
			lines.Remove(lineRenderer);
	}

	void CalcutateRadius()
	{

	}
}
