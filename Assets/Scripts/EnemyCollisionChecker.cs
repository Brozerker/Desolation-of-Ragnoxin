using UnityEngine;
using System.Collections;


public class EnemyCollisionChecker : enemyController {
    public GameObject parent;
    private BoxCollider2D attackArea;
    private int offset;

	void Start () {
        attackArea = GetComponent<BoxCollider2D>();

        float newX = parent.GetComponent<BoxCollider2D>().size.x / 2;
        Vector2 newSize = new Vector2(parent.GetComponent<BoxCollider2D>().size.x / 2, 0.0f);

        offset = 1;
        if (facingLeft) offset = -1;
        Vector2 newOffset = new Vector2(attackArea.size.x * offset, 0.0f);

        attackArea.size = newSize;
        attackArea.offset = newOffset;
	}

	void Update () {
        if (facingLeft) offset = -1;
        else offset = 1;

        Vector2 newOffset = new Vector2(attackArea.size.x * offset, 0.0f);
        attackArea.offset = newOffset;
	}

    void OnTriggerEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Obstacle") {
            // turn around
        }

        if (other.gameObject.tag == "Player") {
            // ATTACK!
        }
    }
}
