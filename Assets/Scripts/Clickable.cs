using UnityEngine;

public class Clickable : MonoBehaviour {
    
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private Material _material;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && HitCheck())
        {
            if (hit.transform.CompareTag("Tile"))
            {
                hit.transform.GetComponent<MeshRenderer>().sharedMaterial = _material;
            }
            else
            {
                _material = hit.transform.GetComponent<MeshRenderer>().sharedMaterial;
            }
        }
        
        if (!Input.GetMouseButtonDown(1) && HitCheck())
        {
            
        }
    }

    private bool HitCheck()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);
    }
}
