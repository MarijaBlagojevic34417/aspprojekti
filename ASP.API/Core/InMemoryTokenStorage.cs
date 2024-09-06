using System.Collections.Concurrent;

namespace ASP.API.Core
{
    public class InMemoryTokenStorage : ITokenStorage
    {
        private static ConcurrentDictionary<Guid, bool> tokens = new ConcurrentDictionary<Guid, bool>();

        public void Add(Guid tokenId)
        {
            int attempts = 0;

            while (attempts < 5)
            {
                var added = tokens.TryAdd(tokenId, true);

                if (added)
                {
                    return;
                }

                attempts++;

                Thread.Sleep(100);
            }

            throw new InvalidOperationException("Token not added to cache.");

        }

        public bool Exists(Guid tokenId)
        {
            if (!tokens.ContainsKey(tokenId))
            {
                return false;
            }

            var isValid = tokens[tokenId];

            return isValid;
        }

        public void Remove(Guid tokenId)
        {
            if (Exists(tokenId))
            {
                var removed = false;
                tokens.Remove(tokenId, out removed);
                //out kao return koja u removed ubacuje vrednost promenljive koju vraca remove


                if (!removed)
                {
                    //kada udje ovde znaci da kljuc vise nije validan
                    throw new InvalidOperationException("Token not removed.");
                }
            }
        }
    }
}
