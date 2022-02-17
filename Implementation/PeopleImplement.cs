using VewMVC.Interfaces;
using VewMVC.Models;

namespace VewMVC.Implementation
{
    public class PeopleImplement : IPeople
    {
        public static List<PersonModel> people = new List<PersonModel>(){

           new PersonModel{
               Id = 1,
               FirstName = "Quan",
               LastName = "Pham Dinh",
               Address = " Thai Binh",
               Gender = "Male"
           },
           new PersonModel{
               Id = 2,
               FirstName = "Hoc",
               LastName = "Nguyen Thai",
               Address = " Ha Noi",
               Gender = "Male"
           },
           new PersonModel{
               Id= 3,
               FirstName = "Thanh",
               LastName = "Do Tien",
               Address = " Hai Duong",
               Gender = "Male"
           },
           new PersonModel{
               Id= 4,
               FirstName = "Thai",
               LastName = "Do Van",
               Address = " Hai Phong",
               Gender = "Male"
           },
           new PersonModel{
               Id= 5,
               FirstName = "Anh",
               LastName = "Do Ngoc",
               Address = " Hai Duong",
               Gender = "Male"
           },
           new PersonModel{
               Id= 6,
               FirstName = "Duy",
               LastName = "Pham Tran",
               Address = " Quang Ninh",
               Gender = "Male"
           },
           new PersonModel{
               Id= 7,
               FirstName = "Huy",
               LastName = "Nguyen Quang",
               Address = " Hung Yen",
               Gender = "Male"
           },
           new PersonModel{
               Id= 8,
               FirstName = "Phong",
               LastName = "Dao Tuan",
               Address = " Nam Dinh",
               Gender = "Male"
           }

    };

        public void Create(PersonModel model)
        {
           
                people.Add(model);
           
        }

        public PersonModel Delete(int id)
        {
             var person = people.Where(person => person.Id == id).FirstOrDefault();
            if(person != null){
                people.Remove(person);
            }
            return person;
        }

        public void Update( PersonModel person)
        {
            var person1 = people.Where(x => x.Id == person.Id).FirstOrDefault();
            person1.FirstName = person.FirstName;
            person1.LastName = person.LastName;
            person1.Gender = person.Gender;
            person1.Address = person.Address;

        }
        

        public List<PersonModel> List()
        {
            return people.OrderBy(x => x.Id).ToList();
        }
    }
}