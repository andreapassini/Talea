using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private Vector2 _head;

    public float waitTime = .5f;
    public float headRadius = 0.1f;
    public GameObject platPrefab;

    public LayerMask layerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        _head = transform.GetChild(0).position;

        StartCoroutine(GrowCor(waitTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GrowCor(float waitTime)
    {
        while (!TopTouching())
        {
            yield return new WaitForSeconds(waitTime);
            
            // Spawn square
            Instantiate(platPrefab, _head, Quaternion.identity);
        }
    }

    private bool TopTouching()
    {
        Collider2D[] results = new Collider2D[] { };
        // Check head
        var size = Physics2D.OverlapCircleNonAlloc(_head, headRadius, results, layerMask);

        if (size != 0)
            return true;
        
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        _head = transform.GetChild(0).position;
        Gizmos.DrawWireSphere(_head, headRadius);
    }
}
