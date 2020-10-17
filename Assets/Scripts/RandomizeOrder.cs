//using System;
using System.Collections;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeOrder : MonoBehaviour//idk if this needs MonoBehavior
{
    //pull recepies from Scriptable and put into list
    //put depending on size of the Order Length, pull x amount of random numbers
    //random numbers are a (0,amntOfRecipes.Length), corresspond to indexes of anmtOfRecipies
    //puts randNumbs into Order Length
    public List<Order> orderList;
    private int indexPos;
    //Order[] orders; //pulls scriptable objects
    //https://stackoverflow.com/questions/53922771/is-there-any-way-to-fill-a-list-with-a-large-number-of-scriptable-objects

    void Start()
    {
        Order[] orders = Resources.LoadAll<Order>("OrderRecipes");//, typeof(Order)).Cast<Order>().ToArray();
        foreach (Order item in orders)
        {
            orderList.Add(item); //puts scriptables in OrderRecipes to orderList list
        }
    }

    public void RandomizeOrderArry(Order[] orders)
    {
        for (int i = 0; i < orders.Length; i++)
        {
            RandomizeIndexPos();
            orders[i] = orderList[indexPos]; //should put a random orderList recipe into indexes of orders
        }
    }

    private void RandomizeIndexPos()
    {
        indexPos = UnityEngine.Random.Range(0, orderList.Count);
    }
}
