using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    /*TODo
    1. สร้าง Header("Movement Setting) ขึ้นมา
        1.1 สร้างตัวแปร moveSpeed = 10f เพื่อควบคุมการเคลื่อนที่ขึ้นลงซ้ายขวาของกล้อง
    2. สร้าง Header("Zoom Setting) ขึ้น
        2.1 สร้างตัวแปร zoomSpeed = 2f
        2.2 สร้างตัวแปร minZoom = 2f
        2.3 สร้างตัวแปร maxZoom = 15f
    3. สร้างตัวแปร cam ให้เป็นประเภท Camera

    */
    

    void Start()
    {
        //Getcomponent ประเภท Camera เข้าไปในตัวแปร cam//
        
    }

    void Update()
    {
        // ประกาศใช้ HandleMovement() และ HandleZoom()
        
    }

    void HandleMovement()
    {
        /*TODO List
        1. สร้างตัวแปร x,y ให้ค่า 0f
        2. เช็คว่า keyboard ยังทำงานอยู่รึเปล่า
        3. เช็คว่า keyboard ได้กด a หรือ กด leftArrowkey รึเปล่า ถ้ากดให้ x = -1f
        4. เช็คว่า keyboard ได้กด d หรือ กด rightArrowKey รึเปล่า ถ้ากดให้ x = 1f
        5. เช็คว่า keyboard ได้กด w หรือ กด upArrorKey รึเปล่า ถ้ากดให้ y = 1f
        6. เช็คว่า keyboard ได้กด s หรือ กด downArrowKey รึเปล่า ถ้ากดให้ y = -1f
        7. สร้างตัวแปร move ประเภท vector3 และ ให้ค่า เป็น ค่า vector3 โดยค่า x คือ x, ค่า y คือ y และ ค่า z คือ 0 
            จากนั้นก็ให้คูณเวกเตอร์ด้วย movespeed และ คูณด้วย Time.deltaTime
        8. ใช้ transform.Translate(move, Space.World) เพื่อค่อยๆเพิ่มค่า x หรือ y โดยอ้างอิงกับแกน x,y,z ของโลก
        */
        
    
    }

    void HandleZoom()
    {
        /*TODO
        1. เช็คว่าเมาส์ทำงานอยู่รึเปล่า
        2. สร้างตัวแปร scrollValue ขึ้นมาโดยให้อ่านและบันทึกค่า scorll.ReadValue().y ของ Mouse ลงไปในตัวแปร
        3. เช็คว่า scrollValue มีค่าไม่เท่ากับ 0
        4. กำหนดให้ค่า cam.orthographicSize ลดค่าลงเพิ่มจาก scrollValue คูณ 0.01 แล้วก็คูณด้วย zoomSpeed
        5. กำหนดให้ค่า cam.orthographicSize มีค่าต่ำสุดเท่ากับ minZoom และ ค่าสูงสุดเท่ากับ maxZoom โดยใช้ Mathf.Clamp
        */
        
    }
}
