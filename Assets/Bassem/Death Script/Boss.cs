using UnityEngine;

public class Boss : MonoBehaviour
{

	public Transform player;
    Animator anim;
    public bool isFlipped = false;
	public Canvas BossCanvas;
	private void Start()
    {
		BossCanvas.enabled = false;
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.enabled = true;
			BossCanvas.enabled = true;

		}
    }
}

