/*
Lab i enlighet med följande:
https://github.com/niklas-hjelm/Programmering-med-C-Sharp-NET22/blob/master/assets/Labb%201.md

Skapat av Hannah Karlsson för ITHS .NET 22

*/
var delStrang = "29535123p48723487597645723645";

for(int i = 0; i < delStrang.Length; i++)
{
    if (int.TryParse(delStrang[i].ToString(), out int result)) {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(delStrang[i]);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(delStrang[i]);
    }
}
Console.ResetColor();