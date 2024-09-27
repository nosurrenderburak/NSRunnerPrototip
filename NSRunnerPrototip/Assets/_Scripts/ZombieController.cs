using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private List<GameObject> bodies = new();
    [SerializeField] private GameObject body;


    private void Start()
    {
        EnabledRandomBody();
    }


    private void EnabledRandomBody()
    {
        var randomBodyIndex = Random.Range(0, bodies.Count);
        bodies[randomBodyIndex].SetActive(true);
    }


    private void Update()
    {
        if (gameObject.activeSelf)
        {
            body.SetActive(IsInViewport(transform.position));
        }
    }
    
    
    public  bool IsInViewport(Vector3 position)
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(position);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
               viewportPoint.z > 0;
    }
}
