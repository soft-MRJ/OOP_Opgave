using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StregSystem
{
    public class User : IComparable
    {

        delegate string UserBalanceNotification(User user, decimal balance);

        // Private variables - used for encapsulation
        private int id;
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
                if (balance < 50)
                    UserBalanceNotification(Nofity);
                balance += value;
            }
        }

        public string Nofity(User user, decimal balance)
        {
            return $"{user.ToString()}, you are below 50kr. Consider adding more money!\nCurrent balance {balance}";
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return firstname + " " + lastname + " " + email;
        }

    }
}
