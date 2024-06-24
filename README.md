# todolist

#Scenario: Aggiungere una nuova attività
  Given l'applicazione è in esecuzione
  When l'utente inserisce il comando "1"
  And l'utente inserisce "Comprare il latte"
  Then l'attività "Comprare il latte" dovrebbe essere aggiunta alla lista

#Scenario: Visualizzare le attività
Given l'applicazione è in esecuzione
And esistono le seguenti attività nella lista:
  | Attività          |
  | Comprare il latte |
  | Studiare          |
When l'utente inserisce il comando "2"
Then l'utente dovrebbe vedere le seguenti attività:
  | Attività          |
  | 1. Comprare il latte |
  | 2. Studiare          |

#Scenario: Rimuovere un'attività
  Given l'applicazione è in esecuzione
  And esistono le seguenti attività nella lista:
    | Attività          |
    | Comprare il latte |
    | Studiare          |
  When l'utente inserisce il comando "3"
  And l'utente inserisce "1"
  Then l'attività "Comprare il latte" dovrebbe essere rimossa dalla lista
  And la lista dovrebbe contenere le seguenti attività:
    | Attività   |
    | 1. Studiare |

#Scenario: Comando non valido
  Given l'applicazione è in esecuzione
  When l'utente inserisce il comando "5"
  Then l'utente dovrebbe vedere un messaggio di errore "Comando non valido. Riprova."

#Scenario: Uscita dall'applicazione
  Given l'applicazione è in esecuzione
  When l'utente inserisce il comando "4"
  Then l'applicazione dovrebbe terminare
  And l'utente dovrebbe vedere il messaggio "Grazie per aver usato la To-Do List. Arrivederci!")

  #Citeria
  Rispetto dei vari scenari
  Utilizzo di più progetti
  Applicazione di tutte le tecniche apprese durante il corso
  Aggiunta di eventuali personalizzazioni
  Codice chiaro e leggibile

