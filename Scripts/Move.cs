using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _currStrength;
    [SerializeField] private float _maxStrength;
    [SerializeField] private float _recoveryRate;

    private void Update()
    {
        _currStrength = Mathf.MoveTowards(_currStrength, _maxStrength, _recoveryRate * Time.deltaTime);
        transform.position = new Vector3(_currStrength, 0, 0);
    }
}
