/*
Lab i enlighet med följande:
https://github.com/niklas-hjelm/Programmering-med-C-Sharp-NET22/blob/master/assets/Labb%201.md

Skapat av Hannah Karlsson för ITHS .NET 22

*/
//Vi måste ta reda på hur vi går från 2 till 2, 9 till 9, 5 till 5, 3 till 3, osv osv.
//Det ska sedan efteråt skrivas ut.
Console.WriteLine("Skriv in en sträng med nummer och siffror: ");
var delStrang = Console.ReadLine() ?? "";
if (delStrang == "example" || delStrang == "ex" || delStrang == "exempel") {
    delStrang = "29535123p48723487597645723645"; //Strängen sig själv
}
int delNum = 0; //Nummer
int delLast = 0; //Sista Position
long delTot = 0;
bool hasRan, canRun, delActive;
Console.ResetColor();

//Detta är ett jättebra system, som vi använder.
for (int delPos = 0; delPos < delStrang.Length; delPos++) {
    delLast = delPos;
    canRun = false;
    hasRan = false;
    delActive = false;
    while (true)
    {
        //bokstäver är inte nummer, därav hoppa över det.
        if (!int.TryParse(delStrang[delPos].ToString(), out int result))
        {
            break;
        }
        //Är det ett nummer? Bra, gör om det til ett nummer
        else
        {
            //Ändra om det till ett nummer
            delNum = int.Parse(delStrang[delPos].ToString());
            //Börja på delPos, kör fram till sista position
            for (int k = delPos; k < delStrang.Length; k++)
            {
                //Finns det ett samma nummer flera gånger? Ja? Bra!
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

            var diff = delLast - delPos;
            if (diff <= 2)
            {
                break;
            }
        }
        if (!canRun)
        {
            break;
        }
        //En for-loop för allt mellan 0 till delSträngs längd
        for (int i = 0; i < delStrang.Length; i++)
        {
            //Vi vill inte visa om det är mindre än delPos.
            if (!hasRan)
            {
                //Är i lika med delPos? Byt över till röd färg (i fokus!)
                if (i == delPos)
                {
                    hasRan = true;
                    delActive = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                //Annars, gul färg!
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            //Detta är i fokus!
            if (int.TryParse(delStrang[i].ToString(), out int output) && delActive) {
                //Är det samma nummer, fast inte samma som position delPos? Stäng av, vi är klara!
                if(output == delNum && delPos != i)
                {
                    delActive = false;
                }
            }
            //Detta är inte i fokus!
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            //Skriv ut delen av strängen!
            Console.Write($"{delStrang[i]}");
        }
        //En funktion som gör om allt mellan delPos till delLast till ett nummer.
        if (long.TryParse(delStrang[delPos..delLast].ToString(), out long delTotOut))
        {
            delTot += delTotOut;
        }
        //Skriv ut en ny rad!
        Console.WriteLine("");
        break;
    }

}
Console.ResetColor();
Console.WriteLine($"Total = {delTot}");