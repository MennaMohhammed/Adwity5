using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adwity.Models;
using System.Data.Entity;

namespace Adwity.Repositories
{
    public class Delete
    {
        public static bool Medicine(int id)
        {
			try
			{
				adwityEntities db = new adwityEntities();
				Medicine medicine = db.Medicines.Find(id);
                if (medicine == null)
                {
                    return false;
                }
                else
                {
                    db.Entry(medicine).State = EntityState.Deleted;
                    if(db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}