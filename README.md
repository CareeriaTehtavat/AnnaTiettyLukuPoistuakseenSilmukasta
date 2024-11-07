# Anna tietty luku poistuakseen silmukasta

## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Katso apuja myös edellisistä tehtävistä.
- Katso myös ensin if-else kirjallinen materiaali & While -silmukan materiaali!
- Break -toiminto
- int.TryParse -toiminto
- Muista ehto tulee normaaleihin sulkeisiin ja toiminto (ehdon ollessa tosi) tulee aaltosulkeisiin!
## TEHTÄVÄNANTO
- Konsolisovellus, jossa käyttäjältä kysytään tiettyä numeroa poistuakseen silmukasta.
- Tarvitset kaksi muuttujaa, string syöte ja int luku. Toteuta sovellukselle syötteen tarkistus, mikäli käyttäjä ei anna numeroa niin kysytään sitä häneltä uudestaan
- Numero, jota sovellus pyytää, voi olla esimerkiksi 4. Kun käyttäjä antaa jonkin muun numeron syötteeksi, tulostuu jokin teksti, esimerkiksi "yritäppä uudelleen". Kun käyttäjä antaa luvun 4 syötteeksi, tulostuu "Onnistuit vihdoinkin! Poistuit silmukasta!"
- HUOM! Tässä tehtävässä on yksi while-silmukka ja kaksi if-lausetta, toinen if lauseesta on ensimmäisen if-lauseen sisällä HINT:


  
```
if (int.TryParse(syöte, out luku))
{
    if (luku == 4)
    {

    }               
}
```
Tekstin pitää olla sama kuin esimerkissa!
Odotettu tulostus:

```
Kirjoita luku 4: en
Et edes antanut lukua..


Kirjoita luku 4: miksi?
Et edes antanut lukua..


Kirjoita luku 4: 3
Yritäpä uudelleen..


Kirjoita luku 4: 6
Yritäpä uudelleen..


Kirjoita luku 4: 4
Onnistuit! Poistuit silmukasta
```

> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
