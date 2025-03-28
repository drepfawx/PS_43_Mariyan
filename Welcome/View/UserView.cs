using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.ViewModel;

namespace Welcome.View
{
    public class UserView
    {
        private UserViewModel _viewModel;
        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void DisplayError()
        {
            throw new Exception("error message lol");
        }

        public void Display()
        {
            Console.WriteLine("--- User Details ---");
            Console.WriteLine($"Name: {_viewModel.Name}");
            Console.WriteLine($"Faculty Number: {_viewModel.FacultyNumber}");
            Console.WriteLine($"Email: {_viewModel.Email}");
            Console.WriteLine($"Role: {_viewModel.Role}");
        }
    }
}
