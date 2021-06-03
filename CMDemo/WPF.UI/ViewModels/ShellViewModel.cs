using Caliburn.Micro;
using System;
using System.Threading.Tasks;
using WPF.UI.Models;

namespace WPF.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName = "Fernando";
        private string _lastName;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => LastName);
            }
        }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName, string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public ShellViewModel()
        {
            People.Add(new PersonModel() { FirstName = "Fernando", LastName = "Santos" });
            People.Add(new PersonModel() { FirstName = "Sue", LastName = "Storm" });
            People.Add(new PersonModel() { FirstName = "John", LastName = "Doe" });
        }

        public async Task LoadPageOne()
        {
            await ActivateItemAsync(new PageOneViewModel());
        }

        public async Task LoadPageTwo()
        {
            await ActivateItemAsync(new PageTwoViewModel());
        }
    }
}