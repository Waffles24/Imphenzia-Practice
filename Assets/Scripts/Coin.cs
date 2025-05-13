using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coinsCollected;
    GameObject parent;

    private void Start()
    {

    }

   

    private void Update()
    {
        
        transform.Rotate(0, Time.deltaTime * 185, 0);

        if (coinsCollected == 1)
        {
            print("You have " + coinsCollected + " Coin");
        }

        else
        {
            print("You have " + coinsCollected + " Coins");
        }
      
        
    }

  




}
