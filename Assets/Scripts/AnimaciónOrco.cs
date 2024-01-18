using UnityEngine;

public class AnimaciónOrco : MonoBehaviour
{
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called");


        // Change the animation based on the waypoint tag
        if (other.gameObject.tag == "Waypoint1")
            {
            Debug.Log("OnTriggerEnter called");
                                                                  
            animator.SetInteger("Cambio", 0);
            }
            else if (other.gameObject.tag == "Waypoint2")
            {
            Debug.Log("OnTriggerEnter called");

            animator.SetInteger("Cambio", 1);
            }
            else if (other.gameObject.tag == "Waypoint3")
            {
            Debug.Log("OnTriggerEnter called");

            animator.SetInteger("Cambio", 2);
            }
        
    }
}
