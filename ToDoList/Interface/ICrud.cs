

namespace ToDoList.Interface
{
    internal interface ICrud<TKey, TEntity>
    {
        void Aggiungi(TEntity entity);
        void Visualizza(int scelta);
        bool Rimuovi(TKey key);
        void Aggiorna(TKey key, TEntity entity);
        IList<TEntity> Ricerca(string queryString);
        TEntity RicercaDaId(TKey key);



    }
}
