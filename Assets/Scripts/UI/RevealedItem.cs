using UnityEngine;

[System.Serializable]
public class RevealedItem
{
    [SerializeField] string _name;
    [SerializeField] GameObject _item;

    public string Name { get => _name; }
    public GameObject Item { get => _item; }
}
