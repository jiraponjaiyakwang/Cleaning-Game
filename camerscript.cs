using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerscript : MonoBehaviour
{
	[SerializeField]
	GameObject  player;
	
	[SerializeField]
	float timeOffset;
	
	[SerializeField]
    Vector2 posOffset;
	
	[SerializeField]
	float leftLimit;
	
	[SerializeField]
	float rightLimit;
	
	[SerializeField]
	float bottomLimit;
	
	[SerializeField]
	float topLimit;
	
	private Vector3 velocity;

	// Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		//camer current position
		Vector3 startPos = transform.position;
		startPos.x += 0f;
		
		//player current position
		Vector3 endPos = player.transform.position;
		
		endPos.x += posOffset.x;
		endPos.y += posOffset.y;
		endPos.z = -10;
		
		//smoothly move camera toward the player position
		transform.position = Vector3.Lerp(startPos, endPos ,timeOffset * Time.deltaTime);
		
		transform.position = new Vector3
		(
			Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
			Mathf.Clamp(transform.position.y, topLimit, bottomLimit),
			transform.position.z
		);

	}
}
