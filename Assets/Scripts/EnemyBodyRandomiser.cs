using UnityEngine;
using System.Collections;

public class EnemyBodyRandomiser : MonoBehaviour {

	[SerializeField]
	private Sprite [] bodies;
	[SerializeField]
	private Sprite [] mouths;
	[SerializeField]
	private Sprite [] eyes;
	[SerializeField]
	private SpriteRenderer bodyRenderer;
	[SerializeField]
	private SpriteRenderer mouthRenderer;
	[SerializeField]
	private SpriteRenderer eyesRenderer;
	

	void Awake () {
		bodyRenderer.sprite = bodies[Random.Range(0, bodies.Length)];
		mouthRenderer.sprite = mouths[Random.Range(0, mouths.Length)];
		eyesRenderer.sprite = eyes[Random.Range(0, eyes.Length)];
	}
	
}

