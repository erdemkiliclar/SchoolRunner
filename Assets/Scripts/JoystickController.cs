using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    
    [SerializeField] Animator _animator;
    public DynamicJoystick dynamicJoystick;
    public float speed;
    public float turnSpeed;



    private void FixedUpdate()
    {
        Run();
    }


    void JoystickMovement()
    {
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        Vector3 addedPos = transform.forward * speed*Time.deltaTime;
        transform.position += addedPos;
        
        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }

    void Run()
    {
        if (Input.GetButton("Fire1"))
        {
            _animator.SetFloat("_isRun", 1);
            JoystickMovement();
        }
        else
        {
           _animator.SetFloat("_isRun", 0);

        }
    }
    

}
