using System.Collections.Generic;

namespace AP.Infrastructure.Caching.Interfaces
{
    public interface IQueueAndListCached
    {
        void EndQueue(string key, string item, long score);

        string DeQueue(string key);

        void EndQueue<T>(string key, T item, long score);

        T DeQueue<T>(string key);

        List<T> DeQueueList<T>(string key);

        long GetSortedSetCount(string key);

        void Push(string key, string item);

        string Pop(string key);

        void SetEntryOrIncrementValueInHash(string hashKey, string key);

        List<string> GetAllEntriesAndRemoveFromHash(string hashkey);

        List<T> GetAllItemsFromQueue<T>(string key);
    }
}