using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    class ResourceDeleteCommand : ResourceCommandBase
    {
        public void PerformAction(Resource resource, ISession dataSession) {
            // been told that the Id is 0 if there is no value sent
            if (resource.Id > 0) {
                try {
                    dataSession.Delete(resource);
                }
                catch (Exception e) {
                    throw (e);
                }
            }

            return;
        }
    }
}