using UnityEngine;

public class Test : MonoBehaviour
{
    int[] myarray = { 1, 2, 3, 4, 5 };
    string[] myarraystring = { "Asim", "Asim", "Asim", "Asim", "Asim" };
    void Start()
    {
        for (int i = 0; i < myarray.Length; i++)
        {
            myarray[i] = 0;
            Debug.Log($"Number in forloop {myarray[i]}");
        }


        foreach (int item in myarray)
        {
            //item = 0;
            Debug.Log($"Number in ForEach {item}");
        }
    }

}
