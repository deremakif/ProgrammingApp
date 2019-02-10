using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Programming.API.Controllers
{
    public class LanguagesController : ApiController
    {
        LanguagesDAL languageDAL = new LanguagesDAL();


        public IHttpActionResult GetSearchByName(string name)
        {
            return Ok("Name: "+name);
        }
        public IHttpActionResult GetSearchBySurname(string surname)
        {
            return Ok("Surname: " + surname);
        }

        [ResponseType(typeof(IEnumerable<Languages>))]
        public IHttpActionResult Get()
        {
            var languages = languageDAL.GetAllLanguages();
            return Ok(languages);    
            //Request.CreateResponse(HttpStatusCode.OK, languages);
        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Get(int id)
        {
            var language = languageDAL.GetLanguageById(id);
            if(language == null)
            {
                return NotFound();
            }
            return Ok(language);
        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post(Languages language)
        {
            if (ModelState.IsValid)
            {
                var createdLanguage = languageDAL.CreateLanguage(language);
                return CreatedAtRoute("DefaultApi", new { id = createdLanguage.ID }, createdLanguage);
            }
            else
                return BadRequest(ModelState);
        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Put(int id, Languages language)
        {
            // id'ye ait kayıt yoksa
            if (languageDAL.IsThereAnyLanguage(id)==false)
            {
                return NotFound();
            }

            // language modeli doğrulanmadıysa
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            // OK
            else
            {
                return Ok(languageDAL.UpdateLanguage(id, language));
            }
        }

        public IHttpActionResult Delete(int id)
        {
            if (languageDAL.IsThereAnyLanguage(id)==false)
            {
                return NotFound();
            }
            else
            {
                languageDAL.DeleteLanguage(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

    }
}
