using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHint : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private GameObject _interactionHint;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private LayerMask _objectsToInteractWith;

    private void Start()
    {
        _interactionHint.SetActive(false);
    }

    private void Update()
    {
        PopupHint();
    }

    private void PopupHint()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distance, _objectsToInteractWith))
        {
            _interactionHint.SetActive(true);
        }
        else
        {
            _interactionHint.SetActive(false);
        }
    }
}
