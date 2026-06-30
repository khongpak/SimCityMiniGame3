using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    /*TODO
    1.ประกาศตัวแปร tickInterval พร้อมกำหนดค่าให้เป็น 2.0
    2. ประกาศตัวแปร timer เพื่อเอาไว้เก็บค่าตัวจับเวลา
    3. ประกาศตัวแปร OnTick เป็นแบบ static event Action
    */
   

    public float tickInterval = 2.0f;
    private float timer;

    //ส่วนที่เพิ่มเติม
    public int day = 1;
    public int month = 1;
    public int year = 2024;
    public static event Action OnDayPassed; // สำหรับคิดเงินแบบวันต่อวัน
    public static event Action OnMonthPassed; //สำหรับคิดเงินแบบเดือนต่อเดือน

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
            CalculateDate();
        }
        
    }

    //ส่วนที่เพิ่มเข้ามา
    void CalculateDate()
    {
        day++;
        if(day > 30) // ให้ 1 เดือน มี 30 วัน
        {
            day = 1;
            month++;
            OnMonthPassed?.Invoke(); //แจ้งเตือนระบบเมื่อครบ1เดือน
        }

        if(month > 12)
        {
            month = 1;
            year++;
        }
        OnDayPassed?.Invoke(); //แจ้งเตือนเมื่อครบ1วัน
    }

    //ฟังก์ชันช่วยจัดรูปแบบวัน
    public string GetDateString()
    {
        return $"{day:D2}/{month:D2}/{year}";
    }

    //------------//
}
