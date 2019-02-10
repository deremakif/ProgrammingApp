using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class LanguagesDAL
    {
        ProgrammingDbEntities db = new ProgrammingDbEntities();

        public IEnumerable<Languages> GetAllLanguages()
        {
            return db.Languages;
        }

        public Languages GetLanguageById(int id)
        {
            return db.Languages.Find(id);
        }

        public Languages CreateLanguage(Languages language)
        {
            db.Languages.Add(language);
            db.SaveChanges();
            return language;
        }

        public Languages UpdateLanguage(int id, Languages language)
        {
            db.Entry(language).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return language;
        }

        public void DeleteLanguage(int id)
        {
            db.Languages.Remove(db.Languages.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyLanguage(int id)
        {
            return db.Languages.Any(x=>x.ID==id);

        }
    }
}
