using UnityEngine;

public class Bai2 : MonoBehaviour
{
    enum POS
    {
        POS_1,
        POS_2,
    }
    Vector3 pos1 = new Vector3(4, -0.5f, 0);
    Vector3 pos2 = new Vector3(0f, -0.5f, 0f);
    Vector3 targetPos;
    POS posEnum;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = pos2;
        posEnum = POS.POS_2;
        this.transform.position = pos1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 1f);
        if (posEnum == POS.POS_2 && transform.position.x <= targetPos.x)
        {
            targetPos = pos1;
            posEnum = POS.POS_1;
        }
        else if (posEnum == POS.POS_1 && transform.position.x >= targetPos.x)
        {
            targetPos = pos2;
            posEnum = POS.POS_2;
        }
    }
}
