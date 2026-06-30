using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    /*TODO
    ประกาศตัวแปร gold เป็นแบบ {get; private set;} = 100
    ประกาศตัวแปร goldText เป็นแบบ TMP_Text
    */
  



    /*TODO
    สร้าง OnEnable และ OnDisable เพื่อรับสมัคร OnBuildingPlaced จาก GridManager เพื่อสั่งให้ 
    HandleBuildingPlaced ทำงาน
    */
   



    void HandleBuildingPlaced(int cost)
    {
        //ทำการเรียกเมธอด DeductGold แล้วส่งค่า cost เข้าไป//
        
        
    }

    public void AddGold(int amount)
    {
        /*TODO
        กำหนดให้ gold เพิ่มค่าขึ้นไป จากจำนวน amount ที่ส่งเข้ามา
        */
       
    }

    public void DeductGold(int amount)
    {
        /*TODO
        ให้ตัวแปร gold หักค่าลบออก จากจำนวน amount ที่ส่งเข้ามา
        ถ้า gold น้อยกว่า 0 ก็ให้ gold มีค่าเท่ากับ 0
        */

        
       
    }
}
