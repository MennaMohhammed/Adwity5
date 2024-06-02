using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using Adwity.Models;

namespace Adwity.Repositories
{
    public class Fetch
    {
        public static int login(string username, string password)
        {
            try
            {
                adwityEntities db = new adwityEntities();

                User user = db.Users.Where(o => o.username == username && o.password == password).FirstOrDefault();

                if (user == null)
                {
                    return 0;
                }
                else
                {
                    return user.id;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static bool CheckUsernameExist(string username)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                User user = db.Users.Where(o => o.username == username).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool MedicineAvaliable(string name, string branches)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                Medicine medicine = db.Medicines.Where(o => o.name.Contains(name)).FirstOrDefault();
                if (medicine == null)
                    return false;
                Medicine exist = db.Medicines.Where(o => o.material.Contains(medicine.material) &&
                o.PharmacyBranch.branch.Contains(branches) && o.name != medicine.name).FirstOrDefault();
                if (exist == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Medicine> AltMedicine(string name, string branches)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                Medicine medicine = db.Medicines.Where(o => o.name.Contains(name)).FirstOrDefault();
                List<Medicine> medicines = db.Medicines.Where(o => o.material.Contains(medicine.material) 
                && o.PharmacyBranch.branch.Contains(branches) && o.name != medicine.name).ToList();
                return medicines;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool MedicineAvaliableRep(string name, string alt, string branches)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                Medicine medicine = db.Medicines.Where(o => o.name.Contains(name)).FirstOrDefault();
                if (medicine == null)
                    return false;
                Medicine exist = db.Medicines.Where(o => o.name.Contains(alt) && 
                o.PharmacyBranch.branch.Contains(branches) && o.name != medicine.name).FirstOrDefault();
                if (exist == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Medicine> RepMedicine(string name, string alt, string branches)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                Medicine medicine = db.Medicines.Where(o => o.name.Contains(name)).FirstOrDefault();
                List<Medicine> medicines = db.Medicines.Where(o => o.name.Contains(alt) && 
                o.PharmacyBranch.branch.Contains(branches) && o.name != medicine.name).ToList();
                return medicines;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool MedicineExist(string name)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                Medicine medicine = db.Medicines.Where(o=>o.name.Contains(name)).FirstOrDefault();
                if(medicine == null) 
                {
                    return false; 
                } 
                else 
                { 
                    return true; 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Medicine MedicineInfo(string name) 
        {
            try
            {
                adwityEntities db = new adwityEntities();
                Medicine medicine = db.Medicines.Where(o => o.name.Contains(name)).FirstOrDefault();

                return medicine;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Medicine> PharmacyHome(int id)
        {
            try
            {
                adwityEntities db = new adwityEntities();
                List<Medicine> list = db.Medicines.Where(o=>o.PharmacyBranch.UserId == id).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Medicine MedicineInfo(int id) 
        {
            try
            {
                adwityEntities db = new adwityEntities();
                Medicine medicine = db.Medicines.Find(id);
                return medicine;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}