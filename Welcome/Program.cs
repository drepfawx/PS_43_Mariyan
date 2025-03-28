using Welcome.Model;
using Welcome.ViewModel;
using Welcome.View;
using Welcome.Others;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Mariyan", "32895723895", "F12345", "mariyan@example.com", Others.UserRolesEnum.ADMIN, 1, DateTime.Now.AddYears(1));
            UserViewModel viewModel = new UserViewModel(user);
            UserView view = new UserView(viewModel);

            view.Display();

            
        }
    }
}
