using VewMVC.Models;

namespace VewMVC.Interfaces
{
    public interface IPeople
    {
        public List<PersonModel> List();
        public void Create(PersonModel model);
        public void Update( PersonModel person);
        public PersonModel Delete(int id);
    
    }
}