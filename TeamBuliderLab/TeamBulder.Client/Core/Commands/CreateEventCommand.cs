using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{

//	CreateEvent <name> <description> <startDate> <endDate>
	public class CreateEventCommand
	{
		public string  Execute(string[] inputArgs)
		{
			Check.CheckLength(6,inputArgs);

			AuthenticationManager.Authorize();

			string eventName = inputArgs[0];

			//Validate Event Name Length
			if (eventName.Length < Constants.MinEventName || eventName.Length > Constants.MaxEventName)
			{
				throw new InvalidOperationException(Constants.ErrorMessages.InvalidArgumentsCount);
			}

			string descrtiption = inputArgs[1];

			//Validate Event Description Length
			if (descrtiption.Length > Constants.MaxDescription || descrtiption.Length < Constants.MinDescription)
			{
				throw new InvalidOperationException(Constants.ErrorMessages.InvalidArgumentsCount);

			}

			DateTime startDateTime ;
			bool isStartDateTime = DateTime.TryParseExact(inputArgs[2] + " " + inputArgs[3], Constants.DateTimeFormat,
				CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime);

			DateTime endDateTime;
			bool isEndDateTime = DateTime.TryParseExact(inputArgs[4] + " " + inputArgs[5], Constants.DateTimeFormat,
				CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime);

			if (!isEndDateTime || !isStartDateTime)
			{
				throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
			}

			if (startDateTime >  endDateTime)
			{
				throw new InvalidOperationException(Constants.ErrorMessages.InvalidStarDate);
			}

			this.CreateEvent(eventName,descrtiption,startDateTime,endDateTime);

			return $"Event {eventName} was created successfully";
		}

		private void CreateEvent(string eventName, string descrtiption, DateTime startDateTime, DateTime endDateTime)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				Event e = new Event()
				{
					Name = eventName,
					Description = descrtiption,
					StartDate = startDateTime,
					EndDate = endDateTime,
					CreatorId = AuthenticationManager.GetCurrentUser().Id
				};
				context.Events.AddOrUpdate(e);
				context.SaveChanges();

			}
		}

	}
}
