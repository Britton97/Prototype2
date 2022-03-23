using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<FoodScriptableObj> myFood = new List<FoodScriptableObj>();
    public FoodScriptableObj activeFood;
    private GameObject foodObject;
    public float horizontalInput;
    public float speed = 10f;
    public float negRange;
    public float posRange;
    private int foodCounter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x ,negRange, posRange);
        transform.position = clampedPos;
        activeFood = myFood[foodCounter];
        SpawnFood();
        SwitchActiveFood();
    }

    private void SpawnFood()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(foodObject != null)
            {
                DestroyImmediate(foodObject, true);
            }
            GameObject food = Instantiate(activeFood.foodModel, transform.position, Quaternion.identity);
            foodObject = food;
            food.transform.localScale = new Vector3(4,4,4);
        }

        if (foodObject)
        {
            foodObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if(foodObject.transform.position.z > 20)
            {
                DestroyImmediate(foodObject, true);
            }
        }
    }

    private void SwitchActiveFood()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Input.GetKeyDown(KeyCode.Q))
        {
            if (foodCounter == myFood.Count -1)
            {
                foodCounter = 0;
                activeFood = myFood[foodCounter];
            }
            else
            {
                foodCounter += 1;
                activeFood = myFood[foodCounter];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !Input.GetKeyDown(KeyCode.E))
        {
            if(foodCounter == 0)
            {
                foodCounter = myFood.Count - 1;
                activeFood = myFood[foodCounter];
            }
            else
            {
                foodCounter -= 1;
                activeFood = myFood[foodCounter];
            }
        }
    }
}
