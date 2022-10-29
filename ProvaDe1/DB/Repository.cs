using System;
using System.Collections.Generic;
using System.Linq;
using ProvaDe1.DB.Entities;


namespace ProvaDe1.DB
{
    public class Repository
    {
        private DBContext DBContext;
        public Repository(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }
        public List<Frase> GetPersons()
        {
            //select * from persons
            List<Frase> result = this.DBContext.Frasi.ToList();
            return result;
        }

        public void InsertFrase(Frase frase)
        {
            this.DBContext.Frasi.Add(frase);
            this.DBContext.SaveChanges();
        }
        public void UpdateFrase(Frase frase)
        {
            this.DBContext.Frasi.Update(frase);
            this.DBContext.SaveChanges();
        }

        public void DeleteFrase(string ID)
        {
            Frase toDelete = this.DBContext.Frasi
                    //.Where(p => p.ID != null && p.ID.Value.ToString() == ID) nel caso fosse nullable
                    .Where(p => p.ID.ToString() == ID)
                    .FirstOrDefault();
            this.DBContext.Frasi.Remove(toDelete);
            this.DBContext.SaveChanges();
        }






    }
}
