using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [Range(0,40)]
    public float speed = 40f;
    public string foodName;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 7);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.transform.name} looking for {foodName}");
        string lower = collision.transform.name.ToLower();
        if (collision.transform.name.Contains(foodName))
        {
            Debug.Log("Got here");
            Destroy(this.gameObject);
        }
    }
}
