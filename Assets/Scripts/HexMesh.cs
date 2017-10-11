using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class HexMesh : MonoBehaviour {

	private Mesh hexMesh;
	private List<Vector3> vertices;
	private List<int> triangles;

	private void Awake () {
		GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
		hexMesh.name = "Hex Mesh";
		vertices = new List<Vector3>();
		triangles = new List<int>();
	}

	private void Start()
	{
		Triangulate();
		GetComponent<MeshCollider>().sharedMesh = hexMesh;
	}

	public void Triangulate () {
		hexMesh.Clear();
		vertices.Clear();
		triangles.Clear();
		
		TriangulateCorners();
		
		hexMesh.vertices = vertices.ToArray();
		hexMesh.triangles = triangles.ToArray();
		hexMesh.RecalculateNormals();
	}
	
	private void TriangulateCorners() {
		var center = transform.localPosition;
		for (var i = 0; i < 6; i++) {
			AddTriangle(
				center,
				center + HexMetrics.corners[i],
				center + HexMetrics.corners[i + 1]
			);
		}
	}
	
	private void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3) {
		var vertexIndex = vertices.Count;
		vertices.Add(v1);
		vertices.Add(v2);
		vertices.Add(v3);
		triangles.Add(vertexIndex);
		triangles.Add(vertexIndex + 1);
		triangles.Add(vertexIndex + 2);
	}
	
}