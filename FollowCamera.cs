using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow; // oyuncu/araba

    // Bu dosyanın bulunduğu nesnenin, yani "Main Camera"nın konumu 
    // arabanın konumuyla aynı olmalıdır.

    void LateUpdate()
    {
        // kamera oyuncuyu/arabayı takip edecek
        // kamera arabadan -10 uzakta durur
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
