/*
Lab i enlighet med följande: https://github.com/niklas-hjelm/Programmering-med-C-Sharp-NET22/blob/master/assets/Labb%201.md
Skapat av Hannah Karlsson för ITHS .NET 22
*/
Console.WriteLine("Skriv in en sträng med siffror och bokstäver (för exempel, skriv 'exempel'): ");
var delStrang = Console.ReadLine() ?? "";
if (delStrang == "example" || delStrang == "exempel" || delStrang == string.Empty) {
    delStrang = "29535123p48723487597645723645"; //Strängen sig själv
}
long delTot = 0;
Console.ResetColor();
for (int delPos = 0; delPos < delStrang.Length; delPos++) {
    int delLast = delPos;
    var canRun = false;
    while (true)
    {
        //Denna del av koden gör så att vi skippar över alla nummer som vi inte vill ha
        if (int.TryParse(delStrang[delPos].ToString(), out int delNum))
        {
            for (int k = delPos; k < delStrang.Length; k++)
            {
                if(int.TryParse(delStrang[k].ToString(), out int thisShouldBeNumber))
                {
                    delLast++;
                    if (delNum == thisShouldBeNumber && delPos != k) {
                        canRun = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            //Kolla skillnaden mellan delLast och delPos. Om den är mindre eller likamed 2 är det troligen samma nummer (dvs 22).
            var diff = delLast - delPos;
            if (diff <= 2 || !canRun)
            {
                break;
            }
        }
        else
        {
            break;
        }
        for (int i = 0; i < delStrang.Length; i++)
        {
            if (i >= delPos && i < delLast)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.Write($"{delStrang[i]}");
        }
        if (long.TryParse(delStrang[delPos..delLast].ToString(), out long delTotOut))
        {
            delTot += delTotOut;
        }
        Console.Write("\n"); //Gör en ny rad.
        break; //Vi är klara, break!
    }

}
Console.ResetColor(); //Byt färgen till standard färgen för användaren
Console.WriteLine($"Total = {delTot}"); //Skriv ut det totala.