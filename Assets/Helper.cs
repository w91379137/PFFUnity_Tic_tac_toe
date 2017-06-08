using UnityEngine;
using System.Collections;

public static class Helper {

	public static GameObject CreatePlaneXZ(float x, float z, float width, float height) {

		string name = "Plane_" + x.ToString() + "_" + z.ToString();
		GameObject plane = new GameObject (name);
		MeshFilter mf = plane.AddComponent (typeof(MeshFilter)) as MeshFilter;
		MeshCollider mc = plane.AddComponent (typeof(MeshCollider)) as MeshCollider;
		plane.AddComponent (typeof(MeshRenderer));

		Mesh m = new Mesh ();
		m.vertices = new Vector3[] {
			new Vector3 (x, 0, z),
			new Vector3 (x + width, 0, z),
			new Vector3 (x + width, 0, z - height),
			new Vector3 (x , 0, z - height)
		};

		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2 (1, 1),
			new Vector2 (1, 0)
		};

		m.triangles = new int[]{ 0, 1, 2, 0, 2, 3 };

		mf.mesh = m;
		mc.sharedMesh = m;
		m.RecalculateBounds ();
		m.RecalculateNormals ();

		return plane;
	}
}
