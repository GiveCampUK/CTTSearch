namespace SearchParty.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Bjma.Utility.DataAccess;
    using Models;

    public class ResourceRepository : IRepository<Resource>
    {
        public Resource GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Resource> GetByIds(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Resource> GetByFreeText(string query, int startPage, int numberOfPages)
        {
            throw new NotImplementedException();
        }

        public Guid Save(Resource objectToSave)
        {
            throw new NotImplementedException();
        }
    }
}