# JsonUserAppFramework

## Projekto aprašymas

Tai C# (.NET Framework) konsolinė programa, kuri vykdo darbą su JSON ir XML duomenų failais. Programa leidžia:

- Nuskaityti vartotojus iš JSON failo
- Pridėti naują vartotoją į JSON objektą
- Naudoti paveldimumą (Admin, RegularUser klasės)
- Nuskaityti duomenis iš antro JSON failo su rolėmis
- Nuskaityti duomenis iš XML failo

## Atliktos užduotys

1. Sukurtas JSON failas `user.json` su pradiniais duomenimis.
2. Nuskaityti visi duomenys iš `user.json` ir išvesti į konsolę naudojant ciklą.
3. Į `user.json` pridėtas naujas vartotojas ir duomenys perrašyti.
4. Sukurtos paveldimos klasės: `Admin`, `RegularUser`, kurios paveldi iš `UserBase`.
5. Sukurtas ir nuskaitytas `user_types.json` failas, kuriame naudojamas `Role` laukas vartotojo tipo nustatymui.
6. Sukurtas ir nuskaitytas `user.xml` failas pagal teorinį XML pavyzdį.
7. Kiekvienas žingsnis įkeltas į GitHub kaip atskiras commit, pridėtas `.gitignore` ir `README.md` failai.

## Naudotos technologijos

- C# (.NET Framework)
- Newtonsoft.Json (JSON nuskaitymui ir rašymui)
- System.Xml.Linq (XML nuskaitymui)

## Projekto struktūra

JsonUserAppFramework/
│
├── Program.cs // Pagrindinis programos kodas
├── user.json // JSON su pagrindiniais vartotojais
├── user_types.json // JSON su paveldėjimu (Admin/User)
├── user.xml // XML vartotojų failas
├── .gitignore // Git ignore failas
└── README.md // Šis dokumentas

## Paleidimo instrukcija

1. Atidaryti projektą Visual Studio aplinkoje.
2. Įsitikinti, kad failai `user.json`, `user_types.json`, `user.xml` yra įtraukti į projektą.
3. Visų failų ypatybėse nustatyti:
   Copy to Output Directory → Copy always
4. Paleisti projektą paspaudus F5 arba mygtuką Start.

## Pavyzdinė programos išvestis

=== Vartotojai iš user.json ===
Vardas: John Doe, Amžius: 30, Miestas: New York
Vardas: Jane Smith, Amžius: 25, Miestas: Los Angeles

=== Vartotojai su rolėmis ===
[Admin] Alice, Amžius: 35, Leidimai: Full
[User] Bob, Amžius: 22, Lygis: Gold

=== Vartotojai iš user.xml ===
Vardas: Jonas, Amžius: 28, Miestas: Vilnius
Vardas: Laura, Amžius: 33, Miestas: Kaunas
