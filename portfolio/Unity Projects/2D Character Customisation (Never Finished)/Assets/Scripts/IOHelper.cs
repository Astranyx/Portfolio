using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;

public class IOHelper
{
    private const string path = "./Assets/Resources/save.save";
    private const string dataPath = "./Assets/Resources/items.data";
    private const string spriteDir = "Mighty Heroes (Rogue) 2D Fantasy Characters Pack/Rogue";

    private static List<OutfitPiece> GetDefaultOptions()
    {
        List<OutfitPiece> options = new List<OutfitPiece>();

        string data = File.ReadAllText(dataPath);

        string[] items = data.Split('\n');
        
        foreach (var item in items)
        {
            string[] itemData = item.Split('|');

            int id = int.Parse(itemData[0]);
            string spritePath = itemData[1];
            int buyPrice = int.Parse(itemData[2]);
            string slot = itemData[3];
            bool owned = itemData[4].Trim() == "Y";


            string a = Path.Combine(spriteDir, spritePath);
            Sprite sprite = Resources.Load<Sprite>(a);

            options.Add(new OutfitPiece(id, sprite, buyPrice, slot, owned));
        }

        return options;
    }

    internal static PlayerData Read()
    {
        PlayerData pd = new PlayerData();
        pd.UnlockedPieces = GetDefaultOptions();
        pd.Currency = 1000;
        pd.Equipment = "11,16,21,27,32,36,40,58,64,69";

        if (!File.Exists(path))
            return pd;

        string s = File.ReadAllText(path);
        string[] sSplit = s.Split('\n');

        foreach (var readOption in sSplit)
        {
            var split = readOption.Split('=');
            if (split[0] == "Currency")
            {
                pd.Currency = int.Parse(split[1]);
            }
            else if (split[0] == "Equipment")
            {
                pd.Equipment = split[1];
                Debug.Log($"Equipment at load {pd.Equipment}");
            }
            else
            {
                if (string.IsNullOrEmpty(split[0])) continue;
                int i = int.Parse(split[0]);
                bool owned = split[1].Trim() == "Y";

                OutfitPiece piece = pd.UnlockedPieces.FirstOrDefault(o => o.GetId() == i);
                if (piece is null) continue;

                piece.SetOwned(owned);
            }
        }

        return pd;
    }

    internal static void Write(PlayerData data)
    {
        StringBuilder sb = new StringBuilder();

        data.UnlockedPieces.ForEach(x =>
        {
            sb.AppendLine($"{x.GetId()}={(x.IsOwned() ? "Y" : "N")}");
        });

        sb.AppendLine($"Currency={data.Currency}");
        sb.AppendLine($"Equipment={data.Equipment}");

        Debug.Log($"Equipment at save: {data.Equipment}");

        using (var sw = File.Create(path))
        {
            sw.Write(Encoding.ASCII.GetBytes(sb.ToString()), 0, sb.ToString().Length);
        }
    }
}
