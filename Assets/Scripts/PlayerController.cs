using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private GameObject shield;
    public static bool isShielded;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        transform.Translate(
            movement.normalized * speed * Time.deltaTime,
            Space.World
        );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShielded = true;
            shield.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isShielded = false;
            shield.SetActive(false);
        }
    }
}