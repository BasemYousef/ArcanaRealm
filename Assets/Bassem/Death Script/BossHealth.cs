using UnityEngine;

public class BossHealth : MonoBehaviour
{
	Animator anim;
	public float fullHealth;
	public float currentHealth;
	private bool isDead = false, isHealed = false;
	public bool isInvulnerable = false;
	//public HealthBar healthBar;
	[SerializeField] GameObject win;

    private void Start()
    {
		currentHealth = fullHealth;
		anim = GetComponent<Animator>();
    }

    public void RecieveDamage(float damage)
	{
		if (isInvulnerable)
			return;

		currentHealth -= damage;
		currentHealth = Mathf.Clamp(currentHealth, 0f, fullHealth);
		//healthBar.SetHealth(300 * (currentHealth / fullHealth));
		
		if (currentHealth <= 150 && isHealed == false)
		{
			anim.SetBool("Heal", true);
			currentHealth += 75;
		//	healthBar.SetHealth(300 * (currentHealth / fullHealth));

			isHealed = true;
		}

		if (currentHealth <= 0)
		{
			anim.SetBool("isDead", true);
			isDead = true;
			this.enabled = false;
			GetComponent<Boss>().enabled = false;
			Destroy(gameObject, 6f);
			win.SetActive(true);
		}

     }
	
}
