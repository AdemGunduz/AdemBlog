using EntityLayer.Concrate;

namespace DataAccessLayer.Repositories
{
    public class context
    {
        public context()
        {
        }

        public object Categories { get; internal set; }

        internal void Add(Category category)
        {
            throw new NotImplementedException();
        }

        internal void Remove(Category category)
        {
            throw new NotImplementedException();
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        internal void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}