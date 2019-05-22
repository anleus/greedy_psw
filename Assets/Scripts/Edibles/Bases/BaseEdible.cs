using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class BaseEdible : BaseEntity
{
    public enum Size { SMALL, MEDIUM, BIG }


    public EdibleData m_data;
    public int prefabIndex;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Awake()
    {
        this.m_data = new EdibleData();
        this.m_data.prefabIndex = this.prefabIndex;

        this.m_data.size = (Size)Random.Range(0, 3);
        this.m_data.originalLocalScale = new Vector3Ser(transform.localScale);

        changeSize();
    }

    protected override void Update()
    {
        this.m_data.currentPosition = new Vector3Ser(transform.position);
        this.m_data.prefabIndex = this.prefabIndex;
    }


    protected void changeSize()
    {

        if (m_data.size == Size.SMALL)
            transform.localScale = m_data.originalLocalScale.toVector() * new Vector2(0.75f, 0.75f);
        if (m_data.size == Size.MEDIUM)
            transform.localScale = m_data.originalLocalScale.toVector() * new Vector2(1f, 1f);
        if (m_data.size == Size.BIG)
            transform.localScale = m_data.originalLocalScale.toVector() * new Vector2(1.25f, 1.25f);

        Debug.Log("Changing Size: " + this + " New Size: " + m_data.size);
    }

    protected int getCaloriesAmount()
    {
        if (m_data.size == Size.SMALL)
            return m_data.baseCalorieAmount;
        if (m_data.size == Size.MEDIUM)
            return m_data.baseCalorieAmount *2;

        return m_data.baseCalorieAmount *3; //FruitSize.BIG
    }

    public void copyData(EdibleData data)
    {
        Debug.Log("Copying Data: " + data);
        this.m_data = data;

        changeSize();
    }
    protected virtual void onEat() { }


}

