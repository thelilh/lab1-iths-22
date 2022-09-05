/*
Lab i enlighet med följande:
https://github.com/niklas-hjelm/Programmering-med-C-Sharp-NET22/blob/master/assets/Labb%201.md

Skapat av Hannah Karlsson för ITHS .NET 22

*/
//Vi måste ta reda på hur vi går från 2 till 2, 9 till 9, 5 till 5, 3 till 3, osv osv.
//Det ska sedan efteråt skrivas ut.
Console.WriteLine("Skriv in en sträng med siffror och bokstäver (för exempel, skriv 'exempel'): ");
var delStrang = Console.ReadLine() ?? "";
if (delStrang == "example" || delStrang == "exempel") {
    delStrang = "29535123p48723487597645723645"; //Strängen sig själv
}
int delNum = 0; //Nummer
int delLast = 0; //Sista Position
long delTot = 0;
bool hasRan, canRun, delActive;
Console.ResetColor();

//Detta är ett jättebra system, som vi använder.
for (int delPos = 0; delPos < delStrang.Length; delPos++) {
    //Sätt delLast till start positionen.
    delLast = delPos;
    //Sätt canRun, hasRun och delActive till false. Alla dessa kommer att testas.
    canRun = false;
    hasRan = false;
    delActive = false;
    while (true)
    {
        //Är det ett nummer? Bra, gör om det til ett nummer
        if (int.TryParse(delStrang[delPos].ToString(), out int result))
        {
            //Ändra om det till ett nummer
            delNum = int.Parse(delStrang[delPos].ToString());
            //Börja på delPos, kör fram till sista position
            for (int k = delPos; k < delStrang.Length; k++)
            {
                //Finns det ett samma nummer flera gånger? Ja? Bra!
                if(int.TryParse(delStrang[k].ToString(), out int thisShouldBeNumber))
                {
                    //Lägg till en till sista positionen, det ska inte alltid var likamed delPos!
                    delLast++;
                    //Är delNum likamed thisShouldBeNumber (ex. 9 = 9) och delPos är inte k (0 != 0)?
                    if (delNum == thisShouldBeNumber && delPos != k) {
                        //Om vi inte gör canRun till true, tror programmet att vi ska break:a
                        canRun = true;
                        //Break... för vi behöver inte testa mer!
                        break;
                    }
                }
                else
                {
                    //Det är inte ett nummer, break!
                    break;
                }
            }

            //Kolla in skillnaden mellan delLast och delPos
            var diff = delLast - delPos;
            //Om skillnaden mellan två tal är mindre eller lika med 2 så är talet 22, 2 eller null.
            if (diff <= 2)
            {
                break;
            }
        }
        else
        {
            //Det går inte att göra om den nuvarande char till en int... det måste vara en bokstav.
            break;
        }
        //Ifall vi inte kan köra, break while
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
                //Är i lika med delPos? 
                if (i == delPos)
                {
                    hasRan = true;
                    delActive = true; //Sätt till aktiv
                    Console.ForegroundColor = ConsoleColor.Red; //Detta är våran "i fokus färg"
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
            //lägg till allt i delTot, det är vårat variabler för det totala!
            delTot += delTotOut;
        }
        Console.Write("\n"); //Gör en ny rad, det ser väldigt skumt ut annars...
        break; //vi är klara, break!
    }

}
Console.ResetColor(); //Byt färgen till standard färgen för användaren
Console.WriteLine($"Total = {delTot}"); //Skriv ut det totala.