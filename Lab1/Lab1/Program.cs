/*
Lab i enlighet med följande: https://github.com/niklas-hjelm/Programmering-med-C-Sharp-NET22/blob/master/assets/Labb%201.md
Skapat av Hannah Karlsson för ITHS .NET 22
*/
//Be användaren om en sträng och spara det till en variabel.
Console.WriteLine("Skriv in en sträng med siffror och bokstäver (för exempel, skriv 'exempel'): ");
var delStrang = Console.ReadLine() ?? "";
//Kolla om användaren vill visa exempelt.
if (delStrang == "example" || delStrang == "exempel" || delStrang == string.Empty) {
    delStrang = "29535123p48723487597645723645";
}
//Återställ det totala till 0.
var delTot = 0L;
//Återställ färgen till användarinställningen.
Console.ResetColor();
//För varje position mellan 0 och längden av texten.
for (var delPos = 0; delPos < delStrang.Length; delPos++) { 
    //Sätt sista position till första positionen, då vi nuvarande är vid "sista position"
    var delLast = delPos;
    //Återställa ifall vi kan köra till nej, då vi ej har kollat det!
    var canRun = false;
    while (true) {
        //Är första tecknet en int? Spara int:en som en variabel.
        if (int.TryParse(delStrang[delPos].ToString(), out var delNum)) {
            //Från delPos till textens längd 
            for (var k = delPos; k < delStrang.Length; k++) {
                //Är just den nuvarande positionen en int och kan vi fortfarande köra? Spara int:en som en variabel.
                if (int.TryParse(delStrang[k].ToString(), out var delStrangNum) && !canRun) {
                    //Lägg till 1 till sista position, då vi ökar sista positionen!
                    delLast++;
                    //Om det första numret är samma som det nuvarande numret och vi är inte på position "0"
                    if (delNum == delStrangNum && delPos != k) {
                        //Då ska vi inte kör längre.
                        canRun = true;
                    }
                }
                else {
                    //Om den nuvarande positionen INTE ett nummer, så har vi kommit till en bokstav och då ska denna process avslutas.
                    break;
                }
            }
            //Om skillnaden mellan första positionen och sista positionen är mindre, eller likamed, 2 ELLER vi kan inte köra, avsluta processen.
            var diff = delLast - delPos;
            if (diff <= 2 || !canRun) {
                break;
            }
        }
        //Är först positionen en bokstav? Avsluta.
        else {
            break;
        }
        //För varje tecken mellan 0 och längden av texten 
        for (var i = 0; i < delStrang.Length; i++) {
            //Är vi mellan (eller på) första position och sista positionen?
            if (i >= delPos && i < delLast) {
                //Markera i rött.
                Console.ForegroundColor = ConsoleColor.Red;
            }
            //Annars
            else {
                //Marker som gult.
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            //Skriv tecknet på samma rad.
            Console.Write(delStrang[i]);
        }
        //Lägg till det som vi markerat i rött till det totala.
        delTot += long.Parse(delStrang[delPos..delLast]);
        //Gör en ny rad. Vi är även klara, så vi ska avsluta processen.
        Console.Write("\n"); 
        break;
    }
}
//Färgen ska återställas till användarinställningen och sedan ska vi skriva ut den totala som vi har räknat fram.
Console.ResetColor();
Console.WriteLine($"Total = {delTot}");