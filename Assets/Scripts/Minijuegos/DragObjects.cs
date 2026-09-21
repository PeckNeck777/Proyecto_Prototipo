using UnityEngine;

public class DragObjects : MonoBehaviour
{
    Vector3 mousePos;
    public virtual Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    public virtual void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }

    public virtual void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }
}
