using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour {

	public GameObject plane;
	public Rigidbody rb;

	void Start () {
		
		for (int x = 0; x < 10; x++) {
			Debug.Log (x);

		}
	}

	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		//如果有滑鼠點擊 而且 從攝影機投射出的光線 有打到物品
		if (Input.GetMouseButton (0) && Physics.Raycast (ray, out hit)) {

			//顯示 紅線
			Debug.DrawLine (ray.origin, hit.point, Color.red, 0.1f, true);

			if (hit.rigidbody != null && hit.rigidbody == rb) {
				
				//在 log 中輸出被點到的 名稱
				Debug.Log (hit.transform.name);
			}
		}
	}
}
