Projekt gry w kości został napisany w języku C#. Główny game loop zaimplementowałem w klasie Game, która koordynuje przebieg rozgrywki.

Zastosowałem podział odpowiedzialności na następujące komponenty:

Models — klasa Player reprezentująca gracza i przechowująca jego wyniki

Utils — klasy logiki aplikacji:
- DiceLogic — obsługuje rzucanie kostkami i przerzuty
- InputControlService — waliduje i przetwarza dane wejściowe użytkownika
- ScoreValidator — implementuje strategię walidacji kombinacji (pattern Strategy) polegającą na weryfikowaniu, czy przypisana w tabeli kombinacja jest prawidłowa
- ScoreTableLogic — zarządza tabelą wyników, wyświetlaniem i podliczaniem punktów


Decyzje projektowe:
- Integers zamiast stringów — wybrałem typ int do obsługi inputów ze względu na łatwość walidacji i bezpieczeństwo typów
- Strategy Pattern — ScoreValidator wykorzystuje pattern Strategy, co umożliwia łatwe dodawanie nowych reguł punktacji bez modyfikacji istniejącego kodu
- Separacja warstw — oddzielenie logiki biznesowej (Utils) od modeli danych (Models) zwiększa czytelność i testowalność

Plany na rozszerzenie aplikacji:
Ze względu na ograniczony czas, nie udało mi się zaimplementować funkcji zapisu i wczytywania gry. Planem na przyszłość jest realizacja tych funkcji za pomocą serializacji i deserializacji JSON:

Zapis gry:
- Stworzenie nowego modelu SaveData zawierającego stan rozgrywki
- Serializacja danych (lista graczy, ich wyniki, aktualny gracz) do pliku JSON
- Przechowywanie zapisów w folderze saves/ projektu

Wczytywanie gry:
- Deserializacja pliku JSON z folderu saves
- Menu umożliwiające wybór konkretnego zapisu
- Wznowienie rozgrywki od gracza, na którym została przerwana


Instrukcja gry:

Po uruchomieniu programu pojawia się menu z opcjami:

- Wystartuj grę — rozpoczyna nową rozgrywkę. System zapyta o liczbę graczy (od 2 do 4 osób)
- Zamknij grę — wychodzi z aplikacji

Przebieg rozgrywki

Pierwszy rzut:

- Gra rozpoczyna się od gracza nr 1
- Na początek system rzuca 5 kostek
- Po wylosowaniu gracz ma dostęp do menu akcji

Opcje dostępne w trakcie tury:

- Przerzuć kostki — umożliwia ponowny rzut wybranych kostek. Gracz ma maksymalnie 3 przerzuty na turę
- Dodaj wynik do tabeli — otwiera tabelę wyników, gdzie gracz wybiera pole do wpisania wyniku. Akcja jest nieodwracalna i kończy turę
- Sprawdź tabelę — wyświetla aktualną tabelę wyników, bez wpływu na liczbę przerzutów

Przerzucanie kostek:

Gracz może wybrać dowolną liczbę kostek do przerzucenia (1-5). Akceptowane są następujące formaty wejścia:

- 1 2 3 (spacje)
- 1,2,3 (przecinki)
- 123 (bez separatorów)
- Jeżeli numer kostki przekracza 5, system wyświetli błąd i nie zmniejszy liczby dostępnych przerzutów.

Koniec gry:

- Rozgrywka trwa do czasu, aż wszyscy gracze wypełnią swoje tabele wyników. Zwycięzcą zostaje gracz z największą liczbą punktów (z uwzględnieniem bonusu za górną tabelę ≥63 punkty).
