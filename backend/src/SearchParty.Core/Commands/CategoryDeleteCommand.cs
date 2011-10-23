using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SearchParty.Core.Models;

namespace SearchParty.Core.Commands
{
    class CategoryDeleteCommand : CategoryCommand
    {
        public void PerformAction(Category category, ISession dataSession) {
            // been told that the Id is 0 if there is no value sent
            if (category.Id > 0) {
                try {
                    dataSession.Delete(category);
                }
                catch (Exception e) {
                    throw (e);
                }
            }

            return;
        }
    }
}
