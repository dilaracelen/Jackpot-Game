using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Unity.VisualScripting;

public class OyunKontrol : MonoBehaviour
{
    public static event Action KolCekildi = delegate { };

    [SerializeField] private TMP_Text kazancText;
    [SerializeField] private Row[] rows;
    [SerializeField] private Transform kol;
    private int kazancDegeri;
    private bool sonucKontrol = false;

    private void Update()
    {
        if (!rows[0].rowDurdu || !rows[1].rowDurdu || !rows[2].rowDurdu)
        {
            kazancDegeri = 0;
            kazancText.text = "Kazanç: ";
            sonucKontrol = false;
        }

        if (rows[0].rowDurdu || rows[1].rowDurdu || rows[2].rowDurdu)
        {
            KontrolEt();
            kazancText.enabled = true;
            kazancText.text = "Kazanç: " + kazancDegeri;       
        }
    }

    private void OnMouseDown()
    {
        if(rows[0].rowDurdu && rows[1].rowDurdu && rows[2].rowDurdu)
        {
            StartCoroutine("KoluCek");
        }
    }

    private IEnumerator KoluCek()
    {
        for(int i = 0; i < 15; i += 5)
        {
            kol.Rotate(0, 0, i);
            yield return new WaitForSeconds(0.1f);
        }

        KolCekildi();

        for(int i = 0; i < 15; i += 5)
        {
            kol.Rotate(0, 0, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void KontrolEt()
    {
        if (rows[0].duranSlot == "Elmas" && rows[1].duranSlot == "Elmas" && rows[2].duranSlot == "Elmas")
            kazancDegeri = 200;

        else if (rows[0].duranSlot == "Taç" && rows[1].duranSlot == "Taç" && rows[2].duranSlot == "Taç")
            kazancDegeri = 400;

        else if (rows[0].duranSlot == "Karpuz" && rows[1].duranSlot == "Karpuz" && rows[2].duranSlot == "Karpuz")
            kazancDegeri = 600;

        else if (rows[0].duranSlot == "Bar" && rows[1].duranSlot == "Bar" && rows[2].duranSlot == "Bar")
            kazancDegeri = 800;

        else if (rows[0].duranSlot == "Yedi" && rows[1].duranSlot == "Yedi" && rows[2].duranSlot == "Yedi")
            kazancDegeri = 1500;

        else if (rows[0].duranSlot == "Kiraz" && rows[1].duranSlot == "Kiraz" && rows[2].duranSlot == "Kiraz")
            kazancDegeri = 3000;

        else if (rows[0].duranSlot == "Limom" && rows[1].duranSlot == "Limon" && rows[2].duranSlot == "Limon")
            kazancDegeri = 5000;

        else if (rows[0].duranSlot == rows[1].duranSlot && rows[0].duranSlot == "Elmas"
              || rows[0].duranSlot == rows[2].duranSlot && rows[0].duranSlot == "Elmas"
              || rows[1].duranSlot == rows[2].duranSlot && rows[1].duranSlot == "Elmas")
            kazancDegeri = 100;

        else if (rows[0].duranSlot == rows[1].duranSlot && rows[0].duranSlot == "Taç"
              || rows[0].duranSlot == rows[2].duranSlot && rows[0].duranSlot == "Taç"
              || rows[1].duranSlot == rows[2].duranSlot && rows[1].duranSlot == "Taç")
            kazancDegeri = 300;

        else if (rows[0].duranSlot == rows[1].duranSlot && rows[0].duranSlot == "Karpuz"
              || rows[0].duranSlot == rows[2].duranSlot && rows[0].duranSlot == "Karpuz"
              || rows[1].duranSlot == rows[2].duranSlot && rows[1].duranSlot == "Karpuz")
            kazancDegeri = 500;

        else if (rows[0].duranSlot == rows[1].duranSlot && rows[0].duranSlot == "Bar"
              || rows[0].duranSlot == rows[2].duranSlot && rows[0].duranSlot == "Bar"
              || rows[1].duranSlot == rows[2].duranSlot && rows[1].duranSlot == "Bar")
            kazancDegeri = 700;

        else if (rows[0].duranSlot == rows[1].duranSlot && rows[0].duranSlot == "Yedi"
              || rows[0].duranSlot == rows[2].duranSlot && rows[0].duranSlot == "Yedi"
              || rows[1].duranSlot == rows[2].duranSlot && rows[1].duranSlot == "Yedi")
            kazancDegeri = 1000;

        else if (rows[0].duranSlot == rows[1].duranSlot && rows[0].duranSlot == "Kiraz"
              || rows[0].duranSlot == rows[2].duranSlot && rows[0].duranSlot == "Kiraz"
              || rows[1].duranSlot == rows[2].duranSlot && rows[1].duranSlot == "Kiraz")
            kazancDegeri = 2000;

        else if (rows[0].duranSlot == rows[1].duranSlot && rows[0].duranSlot == "Limon"
              || rows[0].duranSlot == rows[2].duranSlot && rows[0].duranSlot == "Limon"
              || rows[1].duranSlot == rows[2].duranSlot && rows[1].duranSlot == "Limon")
            kazancDegeri = 4000;

        sonucKontrol = true;
    }
}
