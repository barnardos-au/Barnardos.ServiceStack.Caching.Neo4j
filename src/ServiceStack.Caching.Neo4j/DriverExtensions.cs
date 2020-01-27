using System;
using Neo4j.Driver;

namespace ServiceStack.Caching.Neo4j
{
    internal static class DriverExtensions
    {
        public static T ReadTxQuery<T>(this IDriver driver, Func<ITransaction, T> work)
        {
            using (var session = driver.Session())
            {
                return session.ReadTransaction(work);
            }
        }

        public static void WriteTxQuery(this IDriver driver, Action<ITransaction> txWorkFn)
        {
            using (var session = driver.Session())
            {
                using (var tx = session.BeginTransaction())
                {
                    txWorkFn(tx);
                    tx.Commit();
                }
            }
        }
        
        public static T WriteTxQuery<T>(this IDriver driver, Func<ITransaction, T> txWorkFn)
        {
            using (var session = driver.Session())
            {
                return session.WriteTransaction(txWorkFn);
            }
        }
    }
}