using AppControleFinanceiro.Models;
using LiteDB;

namespace AppControleFinanceiro.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LiteDatabase _database;
        private readonly string collectioName = "transactions";
        public TransactionRepository(LiteDatabase database)
        {
            _database = database;
        }

        public List<Transaction> GetAll()
        {
           return _database.GetCollection<Transaction>(collectioName).Query().OrderByDescending(a=> a.Date).ToList();
        }

        public void Add(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectioName);
            col.Insert(transaction);
            col.EnsureIndex(a => a.Date);
        }

        public void Update(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectioName);
            col.Update(transaction);

        }

        public void Delete(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectioName);
            col.Delete(transaction.Id);
        }

    }
}
