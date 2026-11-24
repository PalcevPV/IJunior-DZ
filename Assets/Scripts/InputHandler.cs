using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private string _xAxis = "Mouse X";
    private string _yAxis = "Mouse Y";
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    public Vector2 Movement =>
        new Vector2(Input.GetAxis(_horizontalAxis), Input.GetAxis(_verticalAxis));

    public Vector2 Look => 
        new Vector2(Input.GetAxis(_xAxis), Input.GetAxis(_yAxis));
}
