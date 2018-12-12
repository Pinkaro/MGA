using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float Health;
    public float maxHealth;

    private SpriteRenderer spriteRenderer;
    public GameObject Healthbar;
    private SpriteRenderer healthbarSpriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (Healthbar != null)
        {
            healthbarSpriteRenderer = Healthbar.GetComponent<SpriteRenderer>();
            healthbarSpriteRenderer.color = new Color(0,1,0,0.5f);
        }
        
    }

	// Update is called once per frame
	void Update ()
	{
	    if (spriteRenderer.material.color != Color.white)
	    {
	        spriteRenderer.material.color = Color.Lerp(spriteRenderer.material.color, Color.white, 0.1f);
        }
    }

    public void ApplyHealthEffect(float effect)
    {
        Health += effect;

        if (Healthbar != null)
        {
            if (Health > maxHealth)
            {
                Healthbar.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                var scale = Healthbar.transform.localScale;
                scale.x = Health / maxHealth;
                Healthbar.transform.localScale = scale;
                healthbarSpriteRenderer.color = Color.Lerp(new Color(1, 0, 0, 0.5f), new Color(0, 1, 0, 0.5f), scale.x);
            }
        }

        if (Health <= 0.0f)
        {
            var killables = transform.GetComponents<IKillable>().ToList();

            foreach (var killable in killables)
            {
                killable.Die();
            }
            Destroy(this);
        }
    }
}
