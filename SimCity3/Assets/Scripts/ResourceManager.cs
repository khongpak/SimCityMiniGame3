using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    /*TODO
    1. ประกาศตัวแปร gold เป็นแบบ {get; private set;} = 100
    2. ประกาศตัวแปร goldText เป็นแบบ TMP_Text
    3. สร้าง OnEnable และ OnDisable เพื่อรับสมัคร OnBuildingPlaced จาก GridManager เพื่อสั่งให้ 
       HandleBuildingPlaced ทำงาน
    4. สร้าง เมธอดขึ้นมาดังนี้
        4.1. HandleBuildingPlaced(int cost) แล้วก็เรียกเมธอทด DeductGold() เพื่อหักเงิน
        4.2. AddGold(int amount) แล้วกำหนดค่า gold เพิ่มขึ้นจากจำนวน amount ที่ส่งเข้ามา
        4.3. DeductGold(int amount) แล้วกำหนดให้ gold ลดลงจากจำนวน amount ที่ส่งเข้ามา
           พร้อมตรวจสอบว่า ถ้า gold น้อยกว่า 0 ก็ให้ค่า gold = 0
        4.4. RefundGold(int amount) แล้วกำหนดค่า gold เพิ่มขึ้นจากจำนวน amount ที่ส่งเข้ามา
    */
   public int gold{get; private set;} = 100;
   public TMP_Text goldText;

    void OnEnable()
    {
        GridManager.OnBuildingPlaced += HandleBuildingPlaced;
    }

    void OnDisable()
    {
        GridManager.OnBuildingPlaced -= HandleBuildingPlaced;
    }

    public void HandleBuildingPlaced(int cost)
    {
        
    }

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void DeductGold(int amount)
    {
        gold -= amount;
        if(gold < 0)
        {
            gold = 0;
        }
    }

    public void RefundGold(int amount)
    {
        gold += amount;
    }
}
