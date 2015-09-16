using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public GameObject fab;
	public int count;
	public Camera volume;

	void Start () {
		for (var i = 0; i < count; i++) {
			var viewportpos = new Vector3(Random.value, Random.value, 
			                              Random.Range(volume.nearClipPlane, volume.farClipPlane));
			var inst = (GameObject)Instantiate(fab, volume.ViewportToWorldPoint(viewportpos), Quaternion.identity);
			inst.transform.SetParent(transform, true);
		}
	}
}
