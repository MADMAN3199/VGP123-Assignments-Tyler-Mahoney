using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    enum CollectibleType
    {
        POWERUP,
        SCORE,
        LIFE
    }

    [SerializeField] CollectibleType curCollectible;
    public int ScoreValue;

    private void Start()
    {
        if (curCollectible == CollectibleType.LIFE)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player curPlayerScript = collision.gameObject.GetComponent<Player>();
            
            switch (curCollectible)
            {
                case CollectibleType.POWERUP:
                    curPlayerScript.StartJumpForceChange();
                    curPlayerScript.score += ScoreValue;
                    break;
                case CollectibleType.LIFE:
                    curPlayerScript.lives++;
                    curPlayerScript.score += ScoreValue;
                    break;
                case CollectibleType.SCORE:
                    curPlayerScript.score += ScoreValue;
                    break;
            }
            Destroy(gameObject);
        }
    }
}