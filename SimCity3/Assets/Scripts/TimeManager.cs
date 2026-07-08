using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    /*TODO
    1.ประกาศตัวแปร tickInterval พร้อมกำหนดค่าให้เป็น 2.0
    2. ประกาศตัวแปร timer เพื่อเอาไว้เก็บค่าตัวจับเวลา
    4. ประกาศตัวแปร day เป็น 1
    5. ประกาศตัวแปร month เป็น 1
    6. ประกาศตัวแปร year เป็น 2024
    7. ประกาศตัวแปร OnDayPassed และ OnMonthPassed เป็นแบบ static event Action
    */
    public static event Action OnDayPassed;
    public static event Action OnMonthPassed;

    public float tickInterval = 2.0f;
    private float timer;
    private int day = 1;
    private int month = 1;
    private int year = 2024;

   

    void Update()
    {
        /*TODO
        กำหนดค่า timer ให้เพิ่มค่า Time.deltaTime
        ถ้า timer มีค่ามากกว่าหรือเท่ากับ tickInterval ก็จะกำหนดให้ timer มีค่าเป็น 0 
        แล้วก็ให้ เรียกฟังก์ชัน CalculateDate
        */ 
        timer += Time.deltaTime;
        if(timer >= tickInterval)
        {
            timer = 0;
            CalculateDate();
        }
    

    }


    void CalculateDate()
    {
        /*TODO
        1. เพิ่มวันขึ้นทีละ 1 
        2. ตรวจสอบถ้าวันมากกว่า 30 แล้ว ให้ day กลายเป็น1 แล้ว month เพิ่มค่าขึ้น 1 จากนั้นประกาศแบบเดือนออกไป
        3. ถ้าเดือนมากกว่า 12 แล้ว ให้ month กลายเป็น 1 แล้ว year เพิ่มค่าขึ้น 1 
        4. ประกาศแบบวันออกไป
        */
        day++;
        OnDayPassed?.Invoke();

        if(day > 30)
        {
            day = 1;
            month++;
            OnMonthPassed?.Invoke();
        }

        if(month > 12)
        {
            month = 1;
            year++;
        }
        
    }

    public string GetDateString()
    {
        /*TODO ให้ return ค่า วัน/เดือน/ปี ออกไป โดยให้ วันและเดือนแสดงตัวเลข2ตำแหน่ง เช่น
        02/04/2026*/

       return $"{day:D2}/{month:D2}/{year}";
    }

}
