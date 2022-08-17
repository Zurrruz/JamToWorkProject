using UnityEngine;
using UnityEngine.UI;

public class ItemSpecification : MonoBehaviour
{
    [SerializeField]
    private ItemName _name;
    [SerializeField]
    private TakeItInHand _takeItInHand;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private GameObject _prefabItem;
    [SerializeField]
    private string _pathItemPrefab;
    [SerializeField, Tooltip("координаты положения предмета в руке")]
    private Vector3 _coordinates;
    [SerializeField, Tooltip("положение поворота предмета в руке")]
    private Vector3 _turnPosition;

    public enum ItemName
    {
        Torch,
        Holder,
        Cube
    }

    public enum TakeItInHand
    { 
        yes,
        no
    }

    public ItemName Name()
    {
        return _name;
    }

    public TakeItInHand TakeItInHandItem()
    {
        return _takeItInHand;
    }

    public Sprite IconItem()
    {
        return _icon;
    }

    public Vector3 LocalCoordinates()
    {
        return _coordinates;
    }

    public Vector3 TurnPosition()
    {
        return _turnPosition;
    }

    public GameObject PrefabsItem()
    {
        return _prefabItem;
    }

    public string PathItemPrefab()
    {
        return _pathItemPrefab;
    }
}
