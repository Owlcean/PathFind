using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomList : IEnumerable
{
    public int[] constItems = new int[] { 1, 3, 5, 6, 7 };
    public IEnumerator GetEnumerator()
    {
        Debug.Log("CustomList:GetEnumerator");
        return new CustomListEnumerator(this);
    }
}

public class CustomListEnumerator : IEnumerator
{
    CustomList list;
    int index;
    int currentElement;
    public CustomListEnumerator(CustomList _list)
    {
        list = _list;
        index = 0;
    }
    public object Current
    {
        get {
            Debug.Log("Current");
            return currentElement;
        }
    }

    public bool MoveNext()
    {
        if (index < list.constItems.Length)
        {
            Debug.Log("MoveNext true");
            currentElement = list.constItems[index++];
            return true;
        }
        else
        {
            Debug.Log("MoveNext false");
            currentElement = -1;
            return false;
        }
    }
    public void Reset()
    {
        Debug.Log("Reset");
        index = 0;
    }
}
