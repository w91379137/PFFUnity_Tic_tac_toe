using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour {

	public GameObject plane;

	public int count_x;
	public int count_z;

	public float lenght;

	void Start () {
		for (int x = -count_x; x <= count_x; x++) {
			for (int z = -count_z; z <= count_z; z++) {
				GameObject add = Helper.CreatePlaneXZ ((float)x - lenght/2, (float)z + lenght/2, lenght, lenght);

				add.transform.Translate(0, 0.01f, 0);

				//add.transform.Translate(0, Random.Range(0.0f, 1.0f), 0);
				add.GetComponent<Renderer>().material.color = new Vector4( Mathf.Abs((float)x / (float)count_x) , Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 0.5f);
			}
		}
	}

	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//如果有滑鼠點擊 而且 從攝影機投射出的光線 有打到物品
		if (Input.GetMouseButton (0) && Physics.Raycast (ray, out hit)) {

			//顯示 紅線
			Debug.DrawLine (ray.origin, hit.point, Color.red, 0.1f, true);
			Debug.Log (hit.transform.name);

			hit.transform.Translate(0, 0.05f, 0);
		}
	}
}
