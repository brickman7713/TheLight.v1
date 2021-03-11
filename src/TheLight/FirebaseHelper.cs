using XamarinFirebase.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinFirebase.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://the-light-7f317.firebaseio.com/");

        // this is more for testing purposes than actual functionality atm
        public async Task<List<Person>> GetAllPersons()
        {
            // list all staff with their primary key and bio
            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  PersonID = item.Object.PersonID,
                  Bio = item.Object.Bio
              }).ToList();
        }

        // fetch single person's primary key, name and bio
        public async Task AddPerson(int personId, string name, string bio)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { PersonID = personId, Name = name, Bio = bio });
        }

        // only fetch a person's primary key
        public async Task<Person> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.PersonID == personId).FirstOrDefault();
        }

        // update entry
        public async Task UpdatePerson(int personID, string name, string bio)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonID == personID).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { PersonID = personID, Name = name, Bio = bio });
        }

        public async Task DeletePerson(int personID)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonID == personID).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
        /* public async Task<List<Program>> GetAllPrograms()
        {

            
        } */

        public async Task AddProgram(int ProgramId, string title, string times)
        {

            await firebase
              .Child("Programs")
              .PostAsync(new Program() { ProgramID = ProgramId, Title = title, Times = times });
        }

        public async Task<Program> GetProgramTitle(int ProgramId)
        {
            return (Program)(await firebase
                .Child("Programs")
                .OnceAsync<Program>()).Select(item => new Program
                {
                    Title = item.Object.Title
                }
                ).Where(a => a.ProgramID == ProgramId);
            // return allPrograms.Where(a => a.ProgramID == ProgramId).FirstOrDefault();
        }

        public async Task UpdateProgram(int ProgramID, string title, string times)
        {
            var toUpdateProgram = (await firebase
              .Child("Programs")
              .OnceAsync<Program>()).Where(a => a.Object.ProgramID == ProgramID).FirstOrDefault();

            await firebase
              .Child("Programs")
              .Child(toUpdateProgram.Key)
              .PutAsync(new Program() { ProgramID = ProgramID, Title = title, Times = times });
        }

        public async Task DeleteProgram(int ProgramID)
        {
            var toDeleteProgram = (await firebase
              .Child("Programs")
              .OnceAsync<Program>()).Where(a => a.Object.ProgramID == ProgramID).FirstOrDefault();
            await firebase.Child("Programs").Child(toDeleteProgram.Key).DeleteAsync();

        }
    }
}

