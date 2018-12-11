using UnityEngine;

public class MoveableWall : MonoBehaviour
{
    public float growSpeed;

    private RaycastHit2D _raycastHit;
    private float _distance;

    private bool _isDone = false;

	// Use this for initialization
	void Start ()
	{
	    int layerMask = 1 << 10;

        _raycastHit = Physics2D.Raycast(transform.position, Vector2.up, float.MaxValue, layerMask);
	    _distance = _raycastHit.distance * 2;
    }
	
	// Update is called once per frame
	void Update () {
	    if (transform.localScale.y < _distance)
	    {
	        transform.localScale = new Vector3(0.15f, transform.localScale.y + growSpeed, 1);
	        var pos = transform.localPosition;
            pos.y += (growSpeed / 2);
	        transform.localPosition = pos;

        }
	}
}
