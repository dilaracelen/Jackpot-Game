using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomDeger;
    private float zamanAralýk;

    public bool rowDurdu;
    public string duranSlot;

    private void Start()
    {
        rowDurdu = true;
        OyunKontrol.KolCekildi += DonmeBasla;
    }

    private void DonmeBasla()
    {
        duranSlot = "";
        StartCoroutine("Don");
    }

    private IEnumerator Don()
    {
        rowDurdu = false;
        zamanAralýk = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -11.25f)
                transform.position = new Vector2(transform.position.x, 9.75f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

            yield return new WaitForSeconds(zamanAralýk);
        }

        randomDeger = Random.Range(60,100);

        randomDeger += (3 - (randomDeger % 3));

        //switch(randomDeger % 3)
        //{
        //    case 1:
        //        randomDeger += 2;
        //        break;

        //    case 2:
        //        randomDeger += 1;
        //        break;
        //}

        for (int i = 0; i< randomDeger; i++)
        {
            if(transform.position.y <= -11.25f)
                transform.position = new Vector2(transform.position.x, 9.75f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

            if (i > Mathf.RoundToInt(randomDeger * 0.25f))
                zamanAralýk = 0.05f;

            if (i > Mathf.RoundToInt(randomDeger * 0.5f))
                zamanAralýk = 0.1f;

            if (i > Mathf.RoundToInt(randomDeger * 0.75f))
                zamanAralýk = 0.15f;

            if (i > Mathf.RoundToInt(randomDeger * 0.95f))
                zamanAralýk = 0.2f;

            yield return new WaitForSeconds(zamanAralýk);
        }

        if (transform.position.y == -11.25f)
            duranSlot = "Diamond";

        else if (transform.position.y == -8.25)
            duranSlot = "Taç";

        else if (transform.position.y == -5.25)
            duranSlot = "Karpuz";

        else if (transform.position.y == -2.25)
            duranSlot = "Bar";

        else if (transform.position.y == 0.75f)
            duranSlot = "Yedi";

        else if (transform.position.y == 3.75f)
            duranSlot = "Kiraz";

        else if (transform.position.y == 6.75f)
            duranSlot = "Limon";

        else if (transform.position.y == 9.75f)
            duranSlot = "Diamond";

        rowDurdu = true;
    }

    private void OnDestroy()
    {
        OyunKontrol.KolCekildi -= DonmeBasla;
    }
}
