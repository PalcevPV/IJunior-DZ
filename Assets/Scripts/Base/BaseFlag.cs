using UnityEngine;

public class BaseFlag : MonoBehaviour
{
    [SerializeField] private Transform _flagPrefab;
    private Transform _flag;

    public bool IsPlaced => _flag != null;

    public Transform Position => _flag;

    public void SetPosition(Vector3 position)
    {
        if (_flag == null)
        {
            _flag = Instantiate(_flagPrefab, position, Quaternion.identity);
        }
        else
        {
            _flag.position = position;
        }
    }

    public void Remove()
    {
        Destroy(_flag.gameObject);
        _flag = null;
    }
}
