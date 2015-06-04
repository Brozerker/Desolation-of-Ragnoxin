using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
    public float distance;
    public float speed;
    
    private Vector3 startPos;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        startPos = transform.position;
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.x < startPos.x || transform.position.x > (startPos.x + distance)) {
            animator.SetBool("moveLeft", !(animator.GetBool("moveLeft")));
            speed *= -1;
        }
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0.0f);
	}
}
