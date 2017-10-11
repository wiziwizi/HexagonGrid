using UnityEngine;

public class HexGrid : MonoBehaviour {

	[SerializeField] private int width = 6;
	[SerializeField] private int height = 6;

	[SerializeField] private GameObject CellPrefab;
	
	private GameObject[] cells;

	private void Awake () {
		cells = new GameObject[height * width];

		for (int z = 0, i = 0; z < height; z++) {
			for (var x = 0; x < width; x++) {
				CreateCell(x, z, i++);
			}
		}
	}
	
	private void CreateCell (int x, int z, int i) {
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 1f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 0.75f);

		cells[i] = Instantiate(CellPrefab);
		cells[i].transform.SetParent(transform, false);
		cells[i].transform.localPosition = position;
	}
}