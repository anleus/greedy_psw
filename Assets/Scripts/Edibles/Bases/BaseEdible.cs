using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEdible : BaseEntity
{
    public enum Size
    {
        SMALL,
        MEDIUM,
        BIG
    }

    private Size size; // Randomly picked in start

    protected int baseCalorieAmount = 0;

    protected override void Start()
    {
        base.Start();

        this.size = (Size)Random.Range(0, 3);
        changeSize();
    }


    protected void changeSize()
    {
        if (this.size == Size.SMALL)
            transform.localScale = transform.localScale * new Vector2(0.75f, 0.75f);
        if (this.size == Size.MEDIUM)
            transform.localScale = transform.localScale * new Vector2(1f, 1f);
        if (this.size == Size.BIG)
            transform.localScale = transform.localScale * new Vector2(1.25f, 1.25f);
    }

    protected int getCaloriesAmount()
    {
        if (this.size == Size.SMALL)
            return baseCalorieAmount;
        if (this.size == Size.MEDIUM)
            return baseCalorieAmount*2;

        return baseCalorieAmount*3; //FruitSize.BIG
    }

    protected virtual void onEat() { }
}
