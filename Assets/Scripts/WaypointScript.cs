using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public Animator animator;
    public int direccion = 0; // 0 = AndarFrente, 1 = AndarLado, 2 = AndarEspaldas

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            switch (direccion)
            {
                case 0:
                    // Andar hacia adelante
                    SetAnimatorParameters(false, false, false);
                    break;
                case 1:
                    // Andar de lado
                    SetAnimatorParameters(false, true, false);
                    break;
                case 2:
                    // Andar hacia atrás
                    SetAnimatorParameters(false, false, true);
                    break;
                default:
                    // Por defecto, andar hacia adelante
                    SetAnimatorParameters(false, false, false);
                    break;
            }
        }

        
        
    }
    private void SetAnimatorParameters(bool flipX, bool walkSide, bool walkBack)
    {
        //animator.SetBool("FlipX", flipX);
        animator.SetBool("AndarFrente", !walkBack);
        animator.SetBool("AndarLado", walkSide);
        animator.SetBool("AndarEspaldas", walkBack);
    }
}

