using UnityEngine;

public class Fabric : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private readonly int[] _startNumbers = { 2, 4, 8, 16, 32, 64 };
    
    public Cube CreateCubeWithRandomNumber(Vector3 position)
    {
        var number = GetRandomStartNumber();
        
        return CreateCube(number, position);
    }
    
    public Cube CreateCube(int number, Vector3 position)
    {
        var cube = Instantiate(_cubePrefab, position, Quaternion.identity);
        
        cube.name = number.ToString();
        cube.SetNumber(number);
        
        return cube;
    }

    private int GetRandomStartNumber()
    {
        var index = Random.Range(0, _startNumbers.Length);
        
        return _startNumbers[index];
    }
}