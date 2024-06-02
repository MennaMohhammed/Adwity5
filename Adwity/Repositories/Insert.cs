using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Adwity.Models;

namespace Adwity.Repositories
{
    public class Insert
    {
        public static bool AddUser(string fname, string lname, string password, string username)
        {
			try
			{
				adwityEntities db = new adwityEntities();
				User user = new User();
				user.first_name = fname;
				user.last_name = lname;
				user.password = password;
				user.username = username;
				db.Users.Add(user);
				if(db.SaveChanges() > 0 )
				{
					return true;
				}
				else
					return false;
			}
			catch (Exception)
			{

				throw;
			}
        }
        public static bool AddPharmacy(string fname, string pname, string password, string username, string image, string[] branches)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                User user = new User();
                user.first_name = fname;
                user.pharmacy = pname;
                user.password = password;
                user.username = username;
                user.license = image;
                user.IsPharmacy = true;
                db.Users.Add(user);
                foreach (var item in branches)
                {
                    if (item != null)
                    {
                        PharmacyBranch branch = new PharmacyBranch();
                        branch.branch = item;
                        branch.UserId = user.id;
                        db.PharmacyBranches.Add(branch);
                    }
                }
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool AddMedicine(string name, string material, int quantity, string production, string expiration, string price, string image, int id)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                List<PharmacyBranch> branches = db.PharmacyBranches.Where(o=>o.UserId == id).ToList();
                foreach (PharmacyBranch item in branches)
                {
                    if (item != null)
                    {
                        Medicine medicine = new Medicine();
                        medicine.name = name;
                        medicine.material = material;
                        medicine.quantity = quantity;
                        medicine.price = decimal.Parse(price);
                        medicine.production_date = DateTime.Parse(production);
                        medicine.expiration_date = DateTime.Parse(expiration);
                        medicine.image = image;
                        medicine.PharmacyId = item.id;
                        db.Medicines.Add(medicine);
                    }
                }
                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}