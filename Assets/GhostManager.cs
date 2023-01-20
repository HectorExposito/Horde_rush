using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    float dissapearTime;
    float actualDissapearTime;
    float dissapearDelay;
    float actualDissapearDelay;
    public BoxCollider2D ghostCollider;
    public SpriteRenderer ghostRenderer;
    private bool alreadyChanged;
    public EnemyManager ghostEnemyManager;
    void Start()
    {
        dissapearTime = 2;
        actualDissapearTime = dissapearTime;
        dissapearDelay = 10;
        actualDissapearDelay = dissapearDelay;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.player))
        {
            collision.GetComponent<PlayerManager>().TakeDamage(ghostEnemyManager.GetEnemy().damage);
        }
    }

    void Update()
    {
        if (actualDissapearDelay <=0)
        {
            if (!alreadyChanged)
            {
                ghostCollider.isTrigger = true;
                ghostRenderer.color = new Color(ghostRenderer.color.r, ghostRenderer.color.g, ghostRenderer.color.b, 0.5f);
                alreadyChanged = true;
            }
            
            if (actualDissapearTime <= 0)
            {
                ghostCollider.isTrigger = false;
                ghostRenderer.color = new Color(ghostRenderer.color.r, ghostRenderer.color.g, ghostRenderer.color.b,1);
                alreadyChanged = false;
                actualDissapearTime = dissapearTime;
                actualDissapearDelay = dissapearDelay;
            }
            else
            {
                actualDissapearTime -= Time.deltaTime;
            }
        }
        else
        {
            actualDissapearDelay -= Time.deltaTime;
        }
    }
}
