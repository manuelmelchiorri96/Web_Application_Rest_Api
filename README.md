# Web Application REST API

Questa è una semplice Web Application REST API per la gestione degli utenti. L'applicazione consente di eseguire operazioni CRUD (Create, Read, Update, Delete) sugli utenti.

## Funzionalità

- **Visualizzazione di tutti gli utenti**: Ottiene tutti gli utenti presenti nel sistema.
- **Visualizzazione di un singolo utente**: Ottiene i dettagli di un utente specificato dall'ID.
- **Aggiunta di un nuovo utente**: Aggiunge un nuovo utente al sistema.
- **Aggiornamento di un utente esistente**: Modifica i dettagli di un utente esistente.
- **Eliminazione di un utente**: Rimuove un utente dal sistema.

## Requisiti

- .NET 8 SDK
- SQL Server (o un altro database supportato da Entity Framework Core)

## Configurazione

1. Clonare il repository:

```bash
git clone https://github.com/manuelmelchiorri96/Web_Application_Rest_Api.git
```

2. Configura la stringa di connessione al database nel file `appsettings.json`.


## API

Il backend fornisce le seguenti API:

User:
- `POST /api/user`: Aggiunge un nuovo utente al sistema.
- `PUT /api/user/{idUser}`: Aggiorna i dettagli di un utente esistente.
- `DELETE /api/user/{idUser}`: Elimina un utente dal sistema.
- `GET /api/user/all`: Restituisce tutti gli utenti nel sistema.
- `GET /api/user/{idDipendente}`:  Restituisce i dettagli di un utente specificato dall'ID.


## Licenza

Questo progetto è rilasciato sotto la licenza [GNU GENERAL PUBLIC LICENSE](LICENSE.txt).