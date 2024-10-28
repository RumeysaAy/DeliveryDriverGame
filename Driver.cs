using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f; // Dönüş Hızı
    [SerializeField] float moveSpeed = 20f; // Hareket Hızı
    [SerializeField] float slowSpeed = 15f; // engele çarptığında hızı
    [SerializeField] float boostSpeed = 30f; // Speed Up nesnesinin üzerinden geçtiğinde hızı

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // sağa veya sola
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // ileri veya geri

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // bu nesne herhangi bir nesneyle çarpıştığında bu fonksiyon çağrılacak
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}
