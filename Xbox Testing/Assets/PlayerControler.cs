using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float speed;
    private Vector2 moveInputValue;

    private void OnMove(InputValue value)
    {
        moveInputValue = value.Get<Vector2>();
        Debug.Log(moveInputValue);
    }

    private void MoveLogicMethod()
    {
        Vector2 result = moveInputValue * speed * Time.deltaTime;
        Vector3 result2 = new Vector3(result.x,0,result.y);
        RB.velocity = result2;
    }

    private void FixedUpdate()
    {
        MoveLogicMethod();
    }
}
