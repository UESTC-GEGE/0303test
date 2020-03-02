using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class func_instrument : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    ////3DMove
    //IEnumerator OnMouseDown()
    //{
    //    //将物体由世界坐标系转化为屏幕坐标系，由vector3 结构体变量ScreenSpace存储，以用来明确屏幕坐标系Z轴的位置
    //    Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
    //    //完成了两个步骤，1由于鼠标的坐标系是2维的，需要转化成3维的世界坐标系，2只有三维的情况下才能来计算鼠标位置与物体的距离，offset即是距离
    //    Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z));
    //    //当鼠标左键按下时
    //    while (Input.GetMouseButton(0))
    //    {
    //        //得到现在鼠标的2维坐标系位置
    //        Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenSpace.z);
    //        //将当前鼠标的2维位置转化成三维的位置，再加上鼠标的移动量
    //        Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
    //        //CurPosition就是物体应该的移动向量赋给transform的position属性
    //        transform.position = CurPosition;
    //        yield return new WaitForFixedUpdate();
    //    }
    //}

    //private void OnMouseEnter()
    //{
    //    OnMouseDown();
    //}

    //移动UI的代码
    public bool dragOnSurfaces = true;

    private Dictionary<int, GameObject> m_DraggingIcons = new Dictionary<int, GameObject>();
    private Dictionary<int, RectTransform> m_DraggingPlanes = new Dictionary<int, RectTransform>();

    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
        m_DraggingIcons[eventData.pointerId] = new GameObject("icon");

        m_DraggingIcons[eventData.pointerId].transform.SetParent(canvas.transform, false);
        m_DraggingIcons[eventData.pointerId].transform.SetAsLastSibling();

        var image = m_DraggingIcons[eventData.pointerId].AddComponent<Image>();
        // The icon will be under the cursor.
        // We want it to be ignored by the event system.
        var group = m_DraggingIcons[eventData.pointerId].AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;

        image.sprite = GetComponent<Image>().sprite;
        image.SetNativeSize();

        if (dragOnSurfaces)
            m_DraggingPlanes[eventData.pointerId] = transform as RectTransform;
        else
            m_DraggingPlanes[eventData.pointerId] = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (m_DraggingIcons[eventData.pointerId] != null)
            SetDraggedPosition(eventData);
    }

    private void SetDraggedPosition(PointerEventData eventData)
    {
        if (dragOnSurfaces && eventData.pointerEnter != null && eventData.pointerEnter.transform as RectTransform != null)
            m_DraggingPlanes[eventData.pointerId] = eventData.pointerEnter.transform as RectTransform;

        var rt = m_DraggingIcons[eventData.pointerId].GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlanes[eventData.pointerId], eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            //rt.rotation = m_DraggingPlanes[eventData.pointerId].rotation;
            rt.rotation = gameObject.GetComponent<RectTransform>().rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_DraggingIcons[eventData.pointerId] != null)
            Destroy(m_DraggingIcons[eventData.pointerId]);

        m_DraggingIcons[eventData.pointerId] = null;
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        var t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
    //代码到此结束

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
