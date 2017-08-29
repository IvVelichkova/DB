

using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{
	public class RegisterUserCommand
	{
		public string Execute(string[] inputArgs)
		{
			//Validate input lenght.
			Check.CheckLength(7,inputArgs);

			string username = inputArgs[0];

			//Validate given username.

			if (username.Length<Constants.MinUsernameLength||username.Length>Constants.MaxUsernameLength)
			{
				throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid,username));
			}

			string password = inputArgs[1];
			//Validate password. 

			if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
			{
				throw  new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid,password));
			}

			string repeatedPassword = inputArgs[2];
			//validate passwords
			if (password!= repeatedPassword)
			{
				throw new InvalidOperationException(Constants.ErrorMessages.PasswordDoesNotMatch);

			}
			string firstName = inputArgs[3];
			if (firstName.Length > Constants.MaxFirstNameLength)
			{
				throw  new InvalidOperationException(Constants.ErrorMessages.InvalidArgumentsCount);
			}

			string lastName = inputArgs[4];
			if (lastName.Length > Constants.MaxLastNameLength)
			{
				throw new InvalidOperationException(Constants.ErrorMessages.InvalidArgumentsCount);
			}

			int age;
			bool isNumber = int.TryParse(inputArgs[5], out age);

			if (!isNumber || age<=0)
			{
				throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
			}

			Gender gender;
			bool isGenderValid = Enum.TryParse(inputArgs[6], out gender);

			if (!isGenderValid)
			{
				throw  new ArgumentException(Constants.ErrorMessages.GenderNotValid);
			}

			if (CommandHelper.IsEventExisting(username))
			{
				throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken,username));
			}

			this.RegisterUser(username, password, firstName, lastName, age, gender);

			return $"User {username} was registered successfully!";
		}

		private void RegisterUser(string username, string password, string firstName, string lastName, int age, Gender gender)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				User u = new User()
				{
					Username = username,
					Password = password,
					FirstName = firstName,
					LastName = lastName,
					Age = age,
					IsDeleted = false,
					Gender = gender
				};

				context.Users.AddOrUpdate(u);
				context.SaveChanges();
			}
		}
	}
}
