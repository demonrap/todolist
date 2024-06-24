namespace ToDoList.Interfaces
{
    public interface ICrud<TEntity,TKey>
    {
        TEntity Entity { get; }
        Dictionary<TKey,TEntity> EntityDictionary { get; set; }
        /// <summary>
        /// Questo metodo aggiunge a un dictionary un'attività con la possibilità di avere la chiave che incrementa di uno ogni volta che aggiungiamo una nuova attività. Al termine stampa l'attività aggiunta.
        /// </summary>
        /// <param name="entity">Attivita entity = l'attività da aggiungere al dictionary</param>
        /// <exception cref="ArgumentException">Se la chiave dell'attività da aggiungere esiste già lancia un'eccezione.</exception>
        void Create(TEntity entity);
        /// <summary>
        ///
        /// </summary>
        /// <param name="entity">Attività entity = La nuova attività aggiornata.</param>
        /// <param name="key">key = la chiave dell'attività da aggiornare.</param>
        /// /// <exception cref="ArgumentException">Se non trova la chiave lancia l'eccezione</exception>
        void Update(TEntity entity,TKey key);
        /// <summary>
        /// Questo metodo aggiunge a un dictionary un'attività con la possibilità di avere la chiave che incrementa di uno ogni volta che aggiungiamo una nuova attività. Al termine stampa l'attività aggiunta.
        /// </summary>
        /// <param name="entity">Attivita entity = l'attività da aggiungere al dictionary</param>
        /// <exception cref="ArgumentException">Se la chiave dell'attività da aggiungere esiste già lancia un'eccezione.</exception>
        bool Delete(TKey key);
        
        /// <summary>
        /// Questo metodo aggiunge gli elementi del dictionary di partenza in una lista che poi ritorna all'utente.
        /// </summary>
        /// <exception cref="ArgumentException">Se la lista è vuota lancia un'eccezione.</exception>
        void GetAll();
        /// <summary>
        /// Cambia lo stato dell'attività da non svolta a svolta.
        /// </summary>
        /// <param name="key"></param>
        void ChangeStatus(TKey key);
        /// <summary>
        /// Metodo che stampa la lista delle attività completate.
        /// </summary>
        void GetCompletedActivitiesList();
        /// <summary>
        /// Metodo che stampa la lista delle attività da completare.
        /// </summary>
        void GetNotCompleteddActivitiesList();


    }
}
