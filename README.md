# RestaurantOrderSystem

Aceasta este o aplicatie consola care permite plasarea si gestionarea comenzilor unui restaurant.

#### Branchul principal este main.

## Design Patterns

Cele doua Design Patterns utilizate in acest proiect sunt:

- **Factory Pattern** – pentru crearea diferitelor tipuri de produse (ex: Pizza, Paste, Băuturi).
- **Command Pattern** – pentru a permite anularea/refacerea comenzilor.

## Unit Tests

Proiectul include următoarele teste unitare:

- **Test_AddItemToOrder**: Verifică dacă un produs poate fi adăugat corect într-o comandă.
- **Test_RemoveItemFromOrder**: Verifică dacă un produs poate fi șters corect dintr-o comandă.
- **Test_AddAndRemoveMultipleItems**: Verifică dacă mai multe produse pot fi adăugate și șterse corect dintr-o comandă.
- **Test_UndoLastCommand**: Verifică dacă funcționalitatea de anulare a ultimei comenzi funcționează corect.
- **Test_AddInvalidProduct**: Verifică dacă încercarea de a crea un produs invalid aruncă o excepție.

## Strucutra proiectului

Proiectul este structurat astfel:

- **Models**: Clasele care vor reprezenta produsele și comenzile.
- **Factory**: Implementarea Factory Pattern.
- **Command**: Implementarea Command Pattern.

## Teste

În acest proiect sunt implementate următoarele teste unitare folosind xUnit:

- Verificarea adăugării și eliminării produselor din comandă.
- Verificarea anularii ultimei comenzi.
- Verificarea comportamentului în cazul unui produs invalid.

## Notă

Trebuie instalat pachetul `xunit.runner.visualstudio` pentru a putea rula testele din Visual Studio.
