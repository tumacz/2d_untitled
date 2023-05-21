using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private float _pickUpRange;
    [SerializeField] private LayerMask _pickUpLayer;

    private Inventory _inventory;

    private void Start()
    {
        GetReferences();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_pickUpLayer & (1 << collision.transform.gameObject.layer)) > 0) //check layerMask
        {
            
            Debug.Log(collision.name);
            Weapon newItem = collision.transform.GetComponent<ItemObject>().item as Weapon;
            //do some logic to replace existing weapon that you are equiped witch

            _inventory.AddItem(newItem);
            Destroy(collision.transform.gameObject);
        }
        else
            return;
    }

    private void GetReferences()
    {
        _inventory = GetComponent<Inventory>();
    }
}
