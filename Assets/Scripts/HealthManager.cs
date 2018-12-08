using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Range(1.0f, 150.0f)] public float Health;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
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
