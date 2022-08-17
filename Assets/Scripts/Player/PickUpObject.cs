using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private float _distace;    
    [SerializeField]
    private LayerMask _objectsToInteractWith;
    public static GameObject _currentOgject;

    [SerializeField]
    private SlotBar _slotBar;
    public static bool _theHandIsBusy = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
    }

    private void PickUp()
    {
        RaycastHit hit;
        GameObject thisItem;

        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _distace, _objectsToInteractWith))
        {
            if (hit.transform.gameObject.GetComponent<ItemSpecification>().TakeItInHandItem() == ItemSpecification.TakeItInHand.yes)
            {
                _slotBar.AddItemInSlot(hit.transform.gameObject, hit.transform.gameObject.GetComponent<ItemSpecification>().IconItem());

                thisItem = hit.transform.gameObject;
                thisItem.GetComponent<BoxCollider>().enabled = false;

                if (hit.transform.gameObject.GetComponent<ItemSpecification>().Name() == ItemSpecification.ItemName.Torch)
                    thisItem.GetComponentInParent<IsHolderBusy>().busy = false;

                thisItem.transform.parent = transform;

                Vector3 localCoordinates = thisItem.GetComponent<ItemSpecification>().LocalCoordinates();
                Vector3 turnPosition = thisItem.GetComponent<ItemSpecification>().TurnPosition();
                thisItem.transform.localPosition = new Vector3(localCoordinates.x, localCoordinates.y, localCoordinates.z);
                thisItem.transform.localEulerAngles = new Vector3(turnPosition.x, turnPosition.y, turnPosition.z);

                if (!_theHandIsBusy)
                {
                    _currentOgject = hit.transform.gameObject;
                    _theHandIsBusy = true;                                     
                }
                else
                {
                    thisItem.SetActive(false);
                }
                
            }

            else if(hit.transform.gameObject.GetComponent<ItemSpecification>().TakeItInHandItem() == ItemSpecification.TakeItInHand.no && _theHandIsBusy)
            {
                if(hit.transform.gameObject.GetComponent<ItemSpecification>().Name() == ItemSpecification.ItemName.Holder && hit.transform.gameObject.GetComponent<IsHolderBusy>().busy == false)
                {
                    if (_currentOgject.GetComponent<ItemSpecification>().Name() == ItemSpecification.ItemName.Torch)
                    {
                        _currentOgject.GetComponent<BoxCollider>().enabled = true;
                        _currentOgject.transform.parent = hit.transform;
                        _currentOgject.transform.localPosition = new Vector3(-0.000816458894f, 0, -0.0544914529f);
                        _currentOgject.transform.localEulerAngles = new Vector3(6.84410679e-06f, 0.949724674f, -1.65088136e-06f);
                        hit.transform.gameObject.GetComponent<IsHolderBusy>().busy = true;
                        _theHandIsBusy = false;
                        _slotBar.DeleteItemInSlots(_currentOgject);
                        _currentOgject = null;
                    }
                }
            }                    
        }        
    }
}
