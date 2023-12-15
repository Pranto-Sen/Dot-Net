using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class PersonRepo
    {
        //public static string GetName(int id)
        //{
        //    return id == 110 ? "Pranto" : "Not Found";
        //}
       public static List<Person> Get()
        {
            var db = new PContext();
            return db.Persons.ToList();
        }
        public static Person Get(int id)
        {
            var db = new PContext();
            return db.Persons.Find(id);

        }
        public static bool Add(Person p)
        {
            var db = new PContext();
            db.Persons.Add(p);
            return db.SaveChanges()>0;
        }
        public static bool Delete(int id)
        {
            var ex = Get(id);
            var db = new PContext();    
            db.Persons.Remove(ex);
            return db.SaveChanges()>0;
        }
        public static bool Update(Person p)
        {
            var ex = Get (p.Id);
            var db = new PContext();
            db.Entry(ex).CurrentValues.SetValues(p);
            return db.SaveChanges()>0;
        }
    }
}
