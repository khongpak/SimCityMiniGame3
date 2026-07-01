using UnityEngine;

[System.Serializable]
public class BuildingData 
{
    /*TODO
        สร้างตัวแปร
        1. string name
        2. GameObject buildingPrefab
        3. int cost
        4. int incomePertick
    */
    public string name;
    public GameObject buildingPrefab;
    public int cost;
    public int incomePerTick;

    // เพิ่มตัวแปรนี้เพื่อระบุขนาด (เช่น กว้าง 2 ช่อง สูง 3 ช่อง เป็นต้น)
    // กำหนดค่าเริ่มต้นเป็น (1, 1) ไว้ก่อนเพื่อไม่ให้ตึกเดิมพังค่ะ
    public Vector2Int buildingSize = Vector2Int.one;

}
