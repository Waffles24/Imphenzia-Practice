using UnityEngine;

public class Mushroom : MonoBehaviour

{
    public int powerupsCollected = 0;

    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * 150, 0);

    }

    

}
