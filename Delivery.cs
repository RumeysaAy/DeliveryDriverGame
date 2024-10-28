using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 0, 0, 1); // paket alındığında araba kırmızı
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1); // beyaz
    [SerializeField] float destroyDelay = 0.5f; // paketin alındıktan sonra yok edilme süresi

    bool hasPackage = false; // paket alındı mı?

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // bu nesne herhangi bir nesneyle çarpıştığında bu fonksiyon çağrılacak
        Debug.Log("Ouch!");
    }

    // bu nesne isTrigger'ı true olan nesnelere temas ettiğinde bu fonksiyon çağrılacak
    private void OnTriggerEnter2D(Collider2D other)
    {
        // hasPackage == false: eğer şu anda paketim yoksa (aynı anda bir pakete sahip olmamı sağlayacak)
        if (other.tag == "Package" && hasPackage == false)
        {
            // tetiklenen nesnenin etiketi Package ise
            Debug.Log("Paket alındı");
            hasPackage = true; // paket alındı
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay); // paketi yok et
        }


        if (other.tag == "Customer" && hasPackage)
        {
            // tetiklenen nesnenin etiketi Customer ise ve paket alındıysa
            Debug.Log("Paket teslim edildi");
            hasPackage = false; // paket teslim edildi (artık bir pakete sahip değil)
            spriteRenderer.color = noPackageColor;
        }
    }
}
