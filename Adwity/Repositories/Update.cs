using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adwity.Models;
using System.Data.Entity;
using System.Data.Common;

namespace Adwity.Repositories
{
    public class Update
    {
        public static bool Password(string password, int id)
        {
            adwityEntities db = new adwityEntities();
            User user = db.Users.Find(id);
            if (user == null)
                return false;
            else
            {
                user.password = password;
                db.Entry(user).State = EntityState.Modified;

                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }
        public static bool Medicine(string name, string material, int quantity, string production, string expiration, string price, string img, int id)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                Medicine medicine = db.Medicines.Find(id);
                if(medicine == null)
                {
                    return false;
                }
                else
                {
                    medicine.name = name;
                    medicine.material = material;
                    medicine.quantity = quantity;
                    medicine.price = decimal.Parse(price);
                    if(production != "")
                        medicine.production_date = DateTime.Parse(production);
                    if(expiration != "")
                        medicine.expiration_date = DateTime.Parse(expiration);
                    if(img != "")
                        medicine.image = img;

                    db.Entry(medicine).State = EntityState.Modified;
                    if(db.SaveChanges() > 0) 
                        return true;
                    else
                        return false;
                }    
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}