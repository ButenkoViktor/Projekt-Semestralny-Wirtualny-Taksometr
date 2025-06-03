🚖 Wirtualny Taksometr -- EASY TAXI --
**Autor:** Viktor Butenko  
**Data:** Maj - Czerwiec 2025  
**Technologie:** C#, WPF, Entity Framework, SQLite  

## 📌 Cel projektu
Celem projektu **Wirtualny Taksometr** jest stworzenie aplikacji desktopowej wspomagającej pracę małej firmy transportowej lub niezależnych kierowców taksówek. Aplikacja ma za zadanie uprościć i zautomatyzować procesy związane z przyjmowaniem zleceń, zarządzaniem flotą pojazdów, bazą klientów oraz kierowców.

## 🎯 Główne funkcjonalności

Aplikacja oferuje zestaw praktycznych funkcji, które obejmują:

- ✅ Dodawanie i edytowanie kierowców, klientów i samochodów;
- ✅ Tworzenie nowych zleceń przejazdu z możliwością przypisania klienta, kierowcy i pojazdu;
- ✅ Obliczanie ceny kursu w zależności od długości trasy i wybranych opcji;
- ✅ Automatyczne nadawanie statusów zlecenia: przyjęte, w trakcie, zakończone, anulowane;
- ✅ Przeglądanie i filtrowanie historii kursów;
- ✅ Możliwość eksportowania podsumowań zleceń;
- ✅ Praca z lokalną relacyjną bazą danych przy użyciu ORM (Entity Framework).

## 💡 Problem, który rozwiązuje aplikacja

Wiele małych firm przewozowych nadal korzysta z ręcznych zapisów, arkuszy kalkulacyjnych lub aplikacji ogólnego przeznaczenia (np. Excel). Prowadzi to do:

- błędów ludzkich (np. pomyłki w danych),
- braku jednolitego systemu historii kursów,
- trudności w podsumowaniu przychodów i wydajności.

Wirtualny Taksometr eliminuje te problemy poprzez scentralizowane, cyfrowe zarządzanie zleceniami.

## ⚙️ Architektura rozwiązania

Aplikacja została zbudowana zgodnie z dobrych praktyk projektowania aplikacji WPF:

- **Warstwa prezentacji (UI)** – oparta na XAML, z rozdzieleniem logiki od widoku (MVVM).
- **Warstwa logiki biznesowej** – klasy zarządzające operacjami na danych i walidacją.
- **Warstwa dostępu do danych** – `DbContext` i modele encji, odwzorowane na relacyjną bazę danych SQLite z użyciem Entity Framework Core.

## 📦 Korzyści dla użytkownika

- Intuicyjny i estetyczny interfejs.
- Szybki dostęp do historii kursów i podsumowań.
- Automatyzacja procesu wyceny kursu.
- Bezpieczeństwo danych dzięki lokalnej bazie danych.

## 📥 Instalacja i uruchomienie aplikacji
- ***Aplikacja została przygotowana jako projekt edukacyjny bez instalatora. Wszystkie niezbędne pliki i baza danych znajdują się w repozytorium, a uruchomienie odbywa się bezpośrednio z Visual Studio.
1. **Pobrać repozytorium** (lub paczkę ZIP) z GitHub:
2. **Otworzyć projekt** w środowisku Visual Studio (wersja 2019/2022 lub nowsza).
3. **Skonfigurować bazę danych**:
- W projekcie znajduje się lokalna baza danych SQLite (`*.db`).
- Plik bazy danych automatycznie kopiuje się do katalogu wyjściowego przy budowaniu projektu.
4. **Zbudować projekt w trybie `Release` lub `Debug`**.
5. **Uruchomić aplikację** klikając przycisk ▶️ `Start` w Visual Studio, lub bezpośrednio uruchamiając plik `.exe` z katalogu.

## 🛠️ Technologie i narzędzia

Projekt został zrealizowany przy użyciu następujących technologii i bibliotek:                           

✅ Język programowania  ----->  C#                                           
✅ Framework  ----->  .NET 6 / .NET Core                           
✅ Interfejs użytkownika (UI)  ----->  WPF (Windows Presentation Foundation)       
✅ ORM  ----->  Entity Framework Core                        
✅ Baza danych  ----->  SQLite (relacyjna, lokalna)                  
✅ IDE  ----->  Visual Studio 2022                          
✅ System kontroli wersji  ----->  Git                                          
✅ Repozytorium online  ----->  GitHub                              


## 🧱 Struktura bazy danych

Baza danych oparta jest o system SQLite i składa się z 4 głównych tabel powiązanych relacjami. Poniżej opis każdej z nich:

### 📌 Tabele:

#### `Klient`
- `Id` (PK) – identyfikator klienta
- `Imie`,
- `Nazwisko`,
- `Telefon`,
- `Email`,
- `MiejsceStartu`,
- `MiejsceOdbioru`,
- `DataZamowienia`

#### `Kierowca`
- `Id` (PK) – identyfikator kierowcy
- `Imie`,
- `Nazwisko`,
- `Telefon`,
- `Email`,
- `ZdjeciePath`

#### `Auto`
- `Id` (PK) – identyfikator samochodu
- `Marka`,
- `Model`,
- `Rejestracja`,
- `VIN`

#### `Zlecenie`
- `Id` (PK) – identyfikator zlecenia
- `KlientId` (FK),
- `KierowcaId` (FK),
- `AdresPoczatkowy`,
- `AdresKoncowy`,
- `Kilometraz`
- `Taryfa`,
- `Cena`,
- `Status`


