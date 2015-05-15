using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Uposlenik : Osoba
    {
        private string username;
        public string Username
        {
            get { return username; }
        }
        
       
        private string password;
        public string Password 
        {
            get { return username; }
        }

        //povezan na : uposlenikViewModel i DBaseSastanci

        public Uposlenik(string firstName, string lastName, string jmbg, string adresa, string brTel, string username, string password) 
            :base(firstName, lastName, jmbg, null, brTel)
        {
            this.username = username;
            this.password = password;
        }
    }
}
