using System;
namespace OOP_Teamwork.Models
{
    public class Teams
    {

        public const int NameMinLength = 5;
        public const int NameMaxLength = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters";
        public const int BoardNameMinLength = 5;
        public const int BoardNameMaxLength = 10;

        private string name;
        private string member;
        private string board;


        public Teams(string name, string member, string board)
        {
            this.name = name;
            this.member = member;
            this.board = board;



        }

        public string Name
        {
            get => name;
            set
            {
                if (name.Length > NameMinLength && name.Length < NameMaxLength)
                {
                    this.name = value;

                }

            }


        public string Member
        {
            get => member;
            set
            {


            }

        }



    }


}
	}
}

