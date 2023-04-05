using System.Transactions;

namespace DAL.Transaction;

public static class TransactionHelp
{
    public static TransactionScope GetTransactionScope()
    {
        const TransactionScopeOption transactionScopeOption 
            = (TransactionScopeOption)TransactionScopeAsyncFlowOption.Enabled;
        var transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted
        };
        
        return new TransactionScope(transactionScopeOption, transactionOptions, 
            TransactionScopeAsyncFlowOption.Enabled);
    }
}