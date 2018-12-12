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
        healthbarSpriteRenderer = Healthbar.GetComponent<SpriteRenderer>();
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
                //healthbarSpriteRenderer.doSmth();
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
