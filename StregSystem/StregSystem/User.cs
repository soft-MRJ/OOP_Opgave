using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StregSystem
{
    public class User : IComparable<User>
    {

        public delegate void UserBalanceNotification(User user, decimal balance);

        // Private variables - used for encapsulation
        private int id;
        private static int idIcrement = 0;
        private string firstname;
        private string lastname;
        private string username;
        private string email;
        private decimal balance;

        /* Count id with static variable
         *   private static id that keeps track of all ids across users
         *   private id for the specific user
         *   set the prefix incremented static id to the specific user's id
         */
        public User(string firstname,
                    string lastname,
                    string username,
                    string email,
                    decimal balance)
        {
            Id = ++idIcrement;
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Email = email;
            Balance = balance;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Firstname { 
            get { return firstname; } 
            set 
            {
                if (value == null)
                    return;
                else
                    firstname = value;
            } 
        }

        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (value == null)
                    return;
                else
                    lastname = value;
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                if (value == null)
                    return;
                else
                {
                    Regex rx = new Regex(@"([A-Za-z0-9]+(_[A-Za-z0-9]+)+)");
                    Match match = rx.Match(value);

                    username = match.Value;
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                Regex rx = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                Match match = rx.Match(value);

                email = match.Value;
            }
        }

        public decimal Balance
        {
            get { return balance; }
            set
            { 
                UserBalanceNotification UserNotify = Nofity;
                if (balance < 50)
                    UserNotify(this, Balance);
                balance += value;
            }
        }

        public void Nofity(User user, decimal balance)
        {
            Console.WriteLine($"{user.ToString()}, you are below 50kr. Consider adding more money!\nCurrent balance {balance}");
        }

        public int CompareTo(User user)
        {
            if (user.Id < Id)
                return 1;
            else if (user.Id > Id)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return firstname + " " + lastname + " " + email;
        }

    }
}
