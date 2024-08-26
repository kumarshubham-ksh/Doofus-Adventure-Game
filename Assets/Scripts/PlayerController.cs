using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float raycastLength = 0.5f;

    Input input;
    Vector2 currentMovement;
    bool movementPressed;
    float speed;

    void Awake()
    {
        input = new Input();

        input.PlayerControls.Move.performed += ctx => 
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        input.PlayerControls.Move.canceled += ctx => {
            currentMovement = Vector2.zero;
            movementPressed = false;
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(movementPressed)
        {
            transform.position = transform.position + new Vector3(currentMovement.x * speed * Time.deltaTime, 0, currentMovement.y * speed * Time.deltaTime);
        }
        
        if(!IsGrounded() && transform.position.y < -4f)
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }
    }

    bool IsGrounded()
    {
        return (Physics.Raycast(transform.position, Vector3.down, raycastLength, groundLayer));
    }

    void OnEnable()
    {
        input.PlayerControls.Enable();
    }

    void OnDisable()
    {
        input.PlayerControls.Disable();
    }
}
