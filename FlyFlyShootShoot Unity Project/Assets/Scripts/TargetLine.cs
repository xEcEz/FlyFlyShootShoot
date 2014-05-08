using UnityEngine;
using System.Collections;

public class TargetLine : MonoBehaviour {
	
	private LineRenderer line;
	
	public Color lineColor = Color.blue;
	public float lineSize = .2f;
	
	// Use this for initialization
	void Start () 
	{
		Material mat = new Material(Shader.Find("Diffuse"));		
		Vector3 objectPos = gameObject.transform.position;
		mat.color = lineColor;
		
		line = gameObject.AddComponent<LineRenderer>();
		line.SetColors(lineColor, lineColor);
		line.SetVertexCount(2);
		line.SetWidth(lineSize, lineSize);
		line.material = mat;
		line.SetPosition(0, objectPos);
		line.SetPosition(1, new Vector3(objectPos.x, objectPos.y, 200));
	}
}
