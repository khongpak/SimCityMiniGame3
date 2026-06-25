using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    /*TODO
    1.ประกาศตัวแปร tickInterval พร้อมกำหนดค่าให้เป็น 2.0
    2. ประกาศตัวแปร timer เพื่อเอาไว้เก็บค่าตัวจับเวลา
    3. ประกาศตัวแปร OnTick เป็นแบบ static event Action
    */
    public static event Action OnTick;

    public float tickInterval = 2.0f;
    private float timer;
   

    void Update()
    {
        /*TODO
        กำหนดค่า timer ให้เพิ่มค่า Time.deltaTime
        ถ้า timer มีค่ามากกว่าหรือเท่ากับ tickInterval ก็จะกำหนดให้ timer มีค่าเป็น 0 
        แล้วก็ให้ OnTick ประกาศ Invoke ออกไป
        */
    
        timer += Time.deltaTime;
        if(timer >= tickInterval)
        {
            timer = 0;
            OnTick?.Invoke();
        }
    }
}
