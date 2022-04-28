using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt_19._1
{
    public partial class ToyShopEntities : DbContext
    {
        private static ToyShopEntities context;
        public static ToyShopEntities GetContext()
        {
            if (context == null)
            {
                context = new ToyShopEntities();
            }
            return context;
        }
    }
}
