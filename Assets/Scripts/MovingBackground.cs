using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private float _moveSpeed;



    private void Update()
    {
        transform.Translate(-1 * _moveSpeed * Time.deltaTime, 0, 0);
        if (_cam.position.x >= transform.position.x + 18f)
        {
            transform.position = new Vector2(_cam.position.x + 18f, transform.position.y);
        }
    }
}
