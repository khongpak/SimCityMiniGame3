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
    8. ในเมธอด Update ให้ กำหนดค่า timer ให้เพิ่มค่า Time.deltaTime
        ถ้า timer มีค่ามากกว่าหรือเท่ากับ tickInterval ก็จะกำหนดให้ timer มีค่าเป็น 0 
        แล้วก็ให้ เรียกฟังก์ชัน CalculateDate
    9. สร้าง เมธอด CalculateDate() โดยให้
        9.1. เพิ่มวันขึ้นทีละ 1 
        9.2. ตรวจสอบถ้าวันมากกว่า 30 แล้ว ให้ day กลายเป็น1 แล้ว month เพิ่มค่าขึ้น 1 จากนั้นประกาศแบบเดือนออกไป
        9.3. ถ้าเดือนมากกว่า 12 แล้ว ให้ month กลายเป็น 1 แล้ว year เพิ่มค่าขึ้น 1 
        9.4. ประกาศแบบวันออกไป
    10. สร้าง เมธอด GetDateString() โดย ให้ return ค่า วัน/เดือน/ปี ออกไป โดยให้ วันและเดือนแสดงตัวเลข2ตำแหน่ง เช่น
        02/04/2026*/
    
}
